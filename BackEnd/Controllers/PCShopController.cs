using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PCShopController : ControllerBase
    { 
        public PCShopContext Context{get; set;}
        public PCShopController(PCShopContext context)
        {
            Context = context;
        }

        [Route("PreuzmiWarehouses")]
        [HttpGet]
        public async Task<List<Warehouse>> PreuzmiWarehouses()
        {
            return await Context.Warehouses.Include(p=>p.Racunari).ThenInclude(p=>p.motherboard).ThenInclude(p=>p.Memory).ToListAsync(); //problem1 ovo ne vraca maticne
        }
        [Route("PreuzmiRacunare")]
        [HttpGet]
        public async Task<List<PC>> PreuzmiRacunare()
        {
            return await Context.PCs.Include(p=>p.motherboard).ToListAsync(); //problem2 ovo ne vraca ram,sata i nvme
        }
        [Route("UpisiWarehouse")]
        [HttpPost]
        public async Task UpisiWarehouse([FromBody] Warehouse warehouse)
        {
            Context.Warehouses.Add(warehouse);
            await Context.SaveChangesAsync();
        }

        [Route("IzmeniWarehouse")]
        [HttpPut]
        public async Task IzmeniWarehouse([FromBody] Warehouse warehouse)
        {
            /*var stariWarehouse = await Context.Warehouses.FindAsync(warehouse.ID);
            stariWarehouse.N = warehouse.N;
            stariWarehouse.Naziv = warehouse.Naziv;*/
            Context.Update<Warehouse>(warehouse);
            await Context.SaveChangesAsync();
        }

        [Route("IzbrisiWarehouse/{id}")]
        [HttpDelete]

        public async Task IzbrisiWarehouse(int id)
        {
            var warehouse = await Context.Warehouses.FindAsync(id);
            Context.Remove(warehouse);
            await Context.SaveChangesAsync();
        }

        [Route("UpisRacunara/{idWarehousea}")]
        [HttpPost]
        public async Task<IActionResult> UpisiRacunar(int idWarehousea,[FromBody] PC pc)
        {
            var warehouse = await Context.Warehouses.FindAsync(idWarehousea);
            pc.Warehouse = warehouse;
            
            if(pc.motherboard.maticna == "X570" || pc.motherboard.maticna == "Z490"){
                pc.motherboard.maxRam=128;
                pc.motherboard.maxSATA=6;
                pc.motherboard.maxNVME=2;
            }

            if(((pc.motherboard.maticna == "B550" || pc.motherboard.maticna == "X570") && pc.motherboard.cpu.ElementAt(0)!='R')||((pc.motherboard.maticna == "B460" || pc.motherboard.maticna == "Z490") && pc.motherboard.cpu.ElementAt(0)!='I'))
            {
                return BadRequest(new {poruka = "Los procesor"});
            }
            else if(pc.motherboard.maticna == "B550" || pc.motherboard.maticna == "B460"){
                int num =0;
                foreach(var v in pc.motherboard.Memory)
                {
                    if(v.Type=="RAM"){
                        num+=v.Size;
                    }
                }
                if(num>64){
                    return BadRequest(new {poruka = "Losa konfiguracija RAM-a"});
                }
                else{
                    Context.PCs.Add(pc);
                    await Context.SaveChangesAsync();
                    return Ok();
                }
            }
            else{
                Context.PCs.Add(pc);
                await Context.SaveChangesAsync();
                return Ok();
            }      
        }
        [Route("IzbrisiRacunar/{id}/{loc}")]
        [HttpDelete]

        public async Task IzbrisiRacunar(int id,int loc)
        {
            var warehouse = await Context.Warehouses.FindAsync(id);
            var pcid = Context.PCs.Where(e=>e.Warehouse==warehouse).Where(e=>e.Poz==loc).Select(e=>e.PCID);
            var pc =await Context.PCs.FindAsync(pcid.First());

            Context.Remove(pc);
            await Context.SaveChangesAsync();
        }

        [Route("UrediMemory/{id}/{loc}")]
        [HttpPost]

        public async Task<IActionResult> UrediMemory(int id,int loc, [FromBody] PC pc)
        {
            var warehouse = await Context.Warehouses.FindAsync(id);
            var pcid = Context.PCs.Where(e=>e.Warehouse==warehouse).Where(e=>e.Poz==loc).Select(e=>e.PCID);
            var pc_U_Bazi = await Context.PCs.FindAsync(pcid.First());
            var moboid = Context.Motherboards.Where(e=>e.PC==pc_U_Bazi).Select(e=>e.MotherboardID);
            Motherboard mobo = await Context.Motherboards.FindAsync(moboid.First());

            int ramNum =0;
            int ramKap = 0;
            int satNum = 0;
            int nvmeNum = 0;
            foreach(var v in pc.motherboard.Memory)
            {
                if(v.Type=="RAM"){
                    ramNum++;
                    ramKap += v.Size;
                }
                else if(v.Type=="SATA")
                    satNum++;
                else
                    nvmeNum++;
            }
            
            if(ramNum > 4 || satNum > pc.motherboard.maxSATA || nvmeNum > pc.motherboard.maxNVME || ramKap > pc.motherboard.maxRam){
                return BadRequest(new {poruka = "Nije moguce uredjenje. Losi parametri"});
            }
            else{
                var memories = await Context.Memories.Where(e=>e.Motherboard==mobo).ToListAsync();
                foreach(var v in memories){
                    Context.Remove(v);
                }
                mobo.Memory=pc.motherboard.Memory;
                await Context.SaveChangesAsync();
                return Ok();
            }
        }

        [Route("PreuzmiPlocu/{idWarehousea}/{loc}")]
        [HttpGet]
        public async Task<List<Memory>> PreuzmiPlocu(int idWarehousea,int loc)
        {
            var warehouse = await Context.Warehouses.FindAsync(idWarehousea);
            var pcid = Context.PCs.Where(e=>e.Warehouse==warehouse).Where(e=>e.Poz==loc).Select(e=>e.PCID);
            var pc = await Context.PCs.FindAsync(pcid.First());
            var moboid = Context.Motherboards.Where(e=>e.PC==pc).Select(e=>e.MotherboardID);
            Motherboard mobo = await Context.Motherboards.FindAsync(moboid.First());
            var memories = Context.Memories.Where(e=>e.Motherboard==mobo);
            return await memories.ToListAsync();
        }


        /*[Route("UpisiPlocu/{idWarehousea}")]
        [HttpPost]
        public async Task UpisiPlocu(int idWarehousea, [FromBody] Motherboard mobo)
        {
            var warehouse = await Context.Warehouses.FindAsync(idWarehousea);
            var pcid = Context.PCs.Where(e=>e.Warehouse==warehouse).Select(e=>e.PCID);
            var pc = await Context.PCs.FindAsync(pcid.First());

            mobo.PC=pc;
            mobo.PCID=pc.PCID;
            Context.Motherboards.Add(mobo);

            await Context.SaveChangesAsync();
        }
         [Route("UpisiRAM/{idWarehousea}")]
        [HttpPost]
        public async Task UpisiRAM(int idWarehousea,[FromBody] Memory mem){
            var warehouse = await Context.Warehouses.FindAsync(idWarehousea);
            var pcid = Context.PCs.Where(e=>e.Warehouse==warehouse).Select(e=>e.PCID);
            var pc = await Context.PCs.FindAsync(pcid.First());
            var moboid = Context.Motherboards.Where(e=>e.PC==pc).Select(e=>e.MotherboardID);
            Motherboard mobo = await Context.Motherboards.FindAsync(moboid.First());

            mobo.RAM.Append(mem);
            Context.Memories.Add(mem);

            await Context.SaveChangesAsync();
        }
        [Route("UpisiSATA/{idWarehousea}")]
        [HttpPost]
        public async Task UpisiSATA(int idWarehousea,[FromBody] Memory mem){
            var warehouse = await Context.Warehouses.FindAsync(idWarehousea);
            var pcid = Context.PCs.Where(e=>e.Warehouse==warehouse).Select(e=>e.PCID);
            var pc = await Context.PCs.FindAsync(pcid.First());
            var moboid = Context.Motherboards.Where(e=>e.PC==pc).Select(e=>e.MotherboardID);
            Motherboard mobo = await Context.Motherboards.FindAsync(moboid.First());

            mobo.SATA.Append(mem);
            Context.Memories.Add(mem);

            await Context.SaveChangesAsync();
        }
        [Route("UpisiNVME/{idWarehousea}")]
        [HttpPost]
        public async Task UpisiNVME(int idWarehousea,[FromBody] Memory mem){
            var warehouse = await Context.Warehouses.FindAsync(idWarehousea);
            var pcid = Context.PCs.Where(e=>e.Warehouse==warehouse).Select(e=>e.PCID);
            var pc = await Context.PCs.FindAsync(pcid.First());
            var moboid = Context.Motherboards.Where(e=>e.PC==pc).Select(e=>e.MotherboardID);
            Motherboard mobo = await Context.Motherboards.FindAsync(moboid.First());

            mobo.NVME.Append(mem);
            Context.Memories.Add(mem);

            await Context.SaveChangesAsync();
        }*/
    }
}