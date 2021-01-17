import {Motherboard} from "./motherboard.js";
export class PC{
    constructor(poz,name,maticna,cpu,ramNum,ramSize,GPU,storage,storageType,kuciste,psu,price)
    {
        this.poz = poz;
        this.name = name;
        let mobo = new Motherboard(maticna,cpu,ramNum,ramSize,GPU,storage,storageType);
        this.motherboard = mobo;
        this.kuciste = kuciste;
        this.psu =psu;
        this.price=price;
        this.miniKontejner=null;
    }
    crtajRacunar(host){
        this.miniKontejner=document.createElement("div");
        this.miniKontejner.className="pc";
        this.miniKontejner.innerHTML="Prazno";
        host.appendChild(this.miniKontejner);
    }
    vratiBoju(){
        if(this.motherboard.cpu.charAt(0)=="R")
            return "red";
        else 
            return "aqua";
    }
    vratiBojuGPU(){
        if(this.motherboard.GPU.charAt(0)=="N")
        return "green";
        else
        return "red";
    }
    azurirajRacunar(poz,name,maticna,cpu,ramNum,ramSize,GPU,storage,storageType,kuciste,psu,price)
    {
        this.poz=poz;
        this.motherboard.azurirajMaticnu(maticna,cpu,ramNum,ramSize,GPU,storage,storageType);
        this.name = name;
        this.kuciste = kuciste;
        this.psu =psu;
        this.price=price;
        this.miniKontejner.innerHTML="";
        let divPrikaz = document.createElement("div");
        divPrikaz.className="divPrikaz";
        divPrikaz.innerHTML="Racunar: "+this.name+", Kuciste: "+this.kuciste+ ", Cena: "+this.price;
        this.miniKontejner.appendChild(divPrikaz);
        this.prikaziRacunar(this.miniKontejner);
    }
    azurirajRacunar2(poz,name,maticna,kuciste,psu,price)
    {
        this.poz=poz;
        this.motherboard.azurirajMaticnu(maticna.maticna,maticna.cpu,0,0,maticna.gpu,0,0)
        maticna.memory.forEach(element => {
            if(element.type=="RAM"){
                this.motherboard.azurirajRam(1,element.size);
            }
            else if(element.type=="SATA"){
                this.motherboard.azurirajStorage(element.size,"SATA");
            }
            else if(element.type=="NVME"){
                this.motherboard.azurirajStorage(element.size,"NVME");
            }
        });
        this.name = name;
        this.kuciste = kuciste;
        this.psu =psu;
        this.price=price;
        this.miniKontejner.innerHTML="";
        console.log(this.motherboard);
        let divPrikaz = document.createElement("div");
        divPrikaz.className="divPrikaz";
        divPrikaz.innerHTML="Racunar: "+this.name+", Kuciste: "+this.kuciste+ ", Cena: "+this.price;
        this.miniKontejner.appendChild(divPrikaz);
        this.prikaziRacunar(this.miniKontejner);
    }
    prikaziRacunar(host){
        const glavniKont = document.createElement("div");
        glavniKont.className="glavniKontPC";
        host.appendChild(glavniKont);

        let labela=null;

        let divUredi=document.createElement("div");
        divUredi.className="divUredi";
        glavniKont.appendChild(divUredi);
        //CPU
        let divRB = null;
        divRB =document.createElement("div");
        divRB.className="kontCPU";
        divRB.innerHTML = this.motherboard.cpu;
        divRB.style.backgroundColor=this.vratiBoju();
        divUredi.appendChild(divRB);
        
        //RAM
        divRB =document.createElement("div");
        divRB.className="kontRAM";
        
        for (let i = 0; i < 4; i++) {
            let divRAM=document.createElement("div");
            divRAM.className="kontRAMSlot";
            if(i<this.motherboard.RAM.length){
                divRAM.innerHTML=this.motherboard.RAM[i].size+" GB";
            }
            divRB.appendChild(divRAM);
        }
        divUredi.appendChild(divRB);
        
        //GPU
        divRB =document.createElement("div");
        divRB.className="kontGPU";
        divRB.innerHTML = this.motherboard.GPU;
        divRB.style.backgroundColor=this.vratiBojuGPU();
        glavniKont.appendChild(divRB);


        divUredi=document.createElement("div");
        divUredi.className="divUredi";
        glavniKont.appendChild(divUredi);

        //NVME
        divRB =document.createElement("div");
        divRB.className="kontNVME";
        if(this.motherboard.maticna=="X570"||this.motherboard.maticna=="Z490"){
            for (let i = 0; i < 2; i++) {
                let divNVME=document.createElement("div");
                divNVME.className="kontNVMESlot";
                if(i<this.motherboard.NVME.length){
                    divNVME.innerHTML=this.motherboard.NVME[i].size+"GB";
                }
                divRB.appendChild(divNVME);
            }
        }
        else{
            let divNVME=document.createElement("div");
                divNVME.className="kontNVMESlot";
                if(this.motherboard.NVME.length>0){
                    divNVME.innerHTML=this.motherboard.NVME[0].size+"GB";
                }
                divRB.appendChild(divNVME);
        }
        divUredi.appendChild(divRB);
        
        //SATA
        divRB =document.createElement("div");
        divRB.className="kontSATA";
        
        if(this.motherboard.maticna=="X570"||this.motherboard.maticna=="Z490"){
            for (let i = 0; i < 6; i++) {
                let divSATA=document.createElement("div");
                divSATA.className="kontSATASlot";
                if(i<this.motherboard.SATA.length){
                    divSATA.innerHTML=this.motherboard.SATA[i].size+"GB";
                }
                divRB.appendChild(divSATA);
            }
        }
        else{
            for (let i = 0; i < 4; i++) {
                let divSATA=document.createElement("div");
                divSATA.className="kontSATASlot";
                if(i<this.motherboard.SATA.length){
                    divSATA.innerHTML=this.motherboard.SATA[i].size+"GB";
                }
                divRB.appendChild(divSATA);
            }
        }
        divUredi.appendChild(divRB);

        //NAPAJANJE
        divRB =document.createElement("div");
        divRB.className="kontNapajanje";
        divRB.innerHTML = this.psu;
        glavniKont.appendChild(divRB);

    }
    zameniPraznim(){
        this.miniKontejner.innerHTML="Prazno";
        this.miniKontejner.style.backgroundColor="white";
    }

    azurirajRam(ramKolicina,ramVelicina){
        this.motherboard.azurirajRam(ramKolicina,ramVelicina);
    }
    azurirajText(){
        this.miniKontejner.innerHTML="";
        let divPrikaz = document.createElement("div");
        divPrikaz.className="divPrikaz";
        divPrikaz.innerHTML="Racunar: "+this.name+", Kuciste: "+this.kuciste+ ", Cena: "+this.price;
        this.miniKontejner.appendChild(divPrikaz);
        this.prikaziRacunar(this.miniKontejner);
    }
    
    azurirajStorage(storageSize,storageType){
        this.motherboard.azurirajStorage(storageSize,storageType);
    }

}