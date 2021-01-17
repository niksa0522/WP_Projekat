import {Memory} from "./memory.js";
export class Motherboard
{
    constructor(maticna,cpu,ramNum,ramSize,GPU,storage,storageType)
    {
        this.maticna=maticna;
        this.cpu=cpu;
        this.GPU=GPU;
        this.maxRam=64;
        this.ramSlots=4;
        this.maxSATA=4;
        this.maxNVME=1;
        this.RAM=[];
        this.SATA=[];
        this.NVME=[];
    }

    azurirajMaticnu(maticna,cpu,ramNum,ramSize,GPU,storage,storageType)
    {
        this.maticna=maticna;
        this.cpu=cpu;
        if(maticna=="X570"||maticna=="Z490"){
            this.maxRam=128;
            this.maxSATA=6;
            this.maxNVME=2;
        }
        for(let i=0;i<ramNum;i++)
        {
            var mem = new Memory(ramSize);
            this.RAM[i]=mem;
        }
        this.GPU=GPU;
        if(storageType=="SATA" && storage != 0){
            var mem = new Memory(storage);
            this.SATA.push(mem);
        }
        else if(storage != 0){
            var mem = new Memory(storage);
            this.NVME.push(mem);
        }
    }
    vratiRam()
    {
        var suma=0;
        this.RAM.forEach(element => {
            suma+=element.size;
        });
        return suma;
    }
    azurirajRam(ramKolicina,ramVelicina){
        if(((this.ramSlots-this.RAM.length)-ramKolicina>=0)&&(this.maxRam-(this.vratiRam()+ramVelicina*ramKolicina))>=0){
            for(let i=0;i<ramKolicina;i++){
                var mem = new Memory(ramVelicina);
                this.RAM.push(mem);
            }
        }
        else
            alert("Nije moguce ubaciti ram");
    }
    azurirajStorage(storageSize,storageType){
        if(storageType=="SATA" && storageSize != 0){
            if((this.maxSATA-this.SATA.length)>0){
                var mem = new Memory(storageSize);
                this.SATA.push(mem);
            }
            else
                alert("Nije moguce ubaciti storage");
        }
        else if(storageType=="NVME" && storageSize != 0){
            if((this.maxNVME-this.NVME.length)>0){
                var mem = new Memory(storageSize);
            this.NVME.push(mem);
            }
            else
                alert("Nije moguce ubaciti storage");
        }
    }
    ramKonfig()
    {
        var str="";
        for(let i=0;i<this.RAM.length;i++){
            if(i!=this.RAM.length-1){
                str += this.RAM[i].size+"GB+";
            }
            else
            str += this.RAM[i].size+"GB";
        }
        return str;
    }
    vratiSATA(){
        var suma=0;
        this.SATA.forEach(element => {
            suma+=element.size;
        });
        return suma;
    }
    vratiNVME(){
        var suma=0;
        this.NVME.forEach(element => {
            suma+=element.size;
        });
        return suma;
    }
    ReturnStorage(){
        return "SATA: "+this.SATA.length+", Kolicina: "+this.vratiSATA()+ "GB NVME: " +this.NVME.length+", Kolicina: "+ this.vratiNVME()+"GB";
    }
}