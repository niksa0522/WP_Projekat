import {PC} from "./pc.js";

export class Warehouse{
    constructor(id,naziv,n)
    {
        this.id = id
        this.naziv=naziv;
        this.n=n;
        this.kontejner=null;
        this.racunari=[];
    }

    dodajRacunar(racunar)
    {
        this.racunari.push(racunar);
    }

    crtajWarehouse(host)
    {
        if(!host)
            throw new Exception("Roditeljski element ne postoji");

        this.kontejner = document.createElement("div");
        this.kontejner.classList.add("kontejner");
        host.appendChild(this.kontejner);

        const kontFormaUredi = document.createElement("div");
        kontFormaUredi.className="kontFormaUredi";
        this.kontejner.appendChild(kontFormaUredi);

        this.crtajFormu(kontFormaUredi);
        this.crtajUrediUkloni(kontFormaUredi);
        this.crtajRacunare(this.kontejner);
    }

    crtajFormu(host)
    {
        let divRb=null;

        const kontForma = document.createElement("div");
        kontForma.className="kontForma";
        host.appendChild(kontForma);

        var elLabela = document.createElement("h3");
        elLabela.innerHTML="Unos Racunara";
        kontForma.appendChild(elLabela);

        divRb=document.createElement("div");
        elLabela = document.createElement("label");
        elLabela.innerHTML="Ime racunara";
        divRb.appendChild(elLabela);

        let tb = document.createElement("input");
        tb.className="ime";
        divRb.appendChild(tb);

        kontForma.appendChild(divRb);

        elLabela = document.createElement("label");
        elLabela.innerHTML="Maticna Ploca:";
        kontForma.appendChild(elLabela);

        elLabela = document.createElement("label");
        elLabela.className="procName";
        elLabela.innerHTML="AMD";
        kontForma.appendChild(elLabela);

        let tipoviPloca=["B550","X570"];

        let opcija=null;
        let labela=null;
        tipoviPloca.forEach((ploca, index)=>{
            divRb=document.createElement("div");
            opcija=document.createElement("input");
            opcija.type="radio";
            opcija.name=this.naziv;
            opcija.value=ploca;

            labela = document.createElement("label");
            labela.innerHTML=ploca;

            divRb.appendChild(opcija);
            divRb.appendChild(labela);
            divRb.className="divMOBO";
            kontForma.appendChild(divRb);
        })

        elLabela = document.createElement("label");
        elLabela.className="procName";
        elLabela.innerHTML="Intel";
        kontForma.appendChild(elLabela);

        tipoviPloca=["B460","Z490"];

        opcija=null;
        labela=null;
        divRb=null;
        tipoviPloca.forEach((ploca, index)=>{
            divRb=document.createElement("div");
            opcija=document.createElement("input");
            opcija.type="radio";
            opcija.name=this.naziv;
            opcija.value=ploca;

            labela = document.createElement("label");
            labela.innerHTML=ploca;

            divRb.appendChild(opcija);
            divRb.appendChild(labela);
            divRb.className="divMOBO";
            kontForma.appendChild(divRb);
        })

        divRb=document.createElement("div");
        let selProc=document.createElement("select");
        labela = document.createElement("label");
        labela.innerHTML="Procesor:";
        divRb.appendChild(labela);
        divRb.appendChild(selProc);

        let tipoviProcesora=["R5 5600X","R7 5800X","R9 5900X","R9 5950X","I5 10600K","I7 10700K","I9 10900K"];

        tipoviProcesora.forEach(element => {
            opcija=document.createElement("option");
            opcija.innerHTML=element;
            opcija.value=element;
            selProc.appendChild(opcija);
        });

        kontForma.appendChild(divRb);

        divRb=document.createElement("div");
        let selRamNumber=document.createElement("select");
        let selRamSize=document.createElement("select");
        labela = document.createElement("label");
        labela.innerHTML="Ram:";
        divRb.appendChild(labela);
        divRb.appendChild(selRamNumber);
        labela = document.createElement("label");
        labela.innerHTML="x";
        divRb.appendChild(labela);
        divRb.appendChild(selRamSize);

        for(let i=1;i<=4;i++)
        {
            opcija=document.createElement("option");
            opcija.innerHTML=i;
            opcija.value=i;
            selRamNumber.appendChild(opcija);
        }
        for(let i=4;i<=32;i=i*2)
        {
            opcija=document.createElement("option");
            opcija.innerHTML=i+"GB";
            opcija.value=i;
            selRamSize.appendChild(opcija);
        }
        kontForma.appendChild(divRb);

        divRb=document.createElement("div");
        let selGPU=document.createElement("select");
        labela = document.createElement("label");
        labela.innerHTML="Graficka kartica:";
        divRb.appendChild(labela);
        divRb.appendChild(selGPU);

        let tipoviGPU=["NVIDIA RTX 3090","NVIDIA RTX 3080", "NVIDIA RTX 3070", "NVIDIA RTX 3060 Ti", "AMD RX 6900", "AMD RX 6800XT", "AMD RX 6800"];

        tipoviGPU.forEach(element => {
            opcija=document.createElement("option");
            opcija.innerHTML=element;
            opcija.value=element;
            selGPU.appendChild(opcija);
        });

        kontForma.appendChild(divRb);

        divRb=document.createElement("div");
        labela = document.createElement("label");
        labela.innerHTML="HDD/SDD:";
        divRb.appendChild(labela);
        tb=document.createElement("input");
        tb.className="storage";
        tb.value=0;
        tb.type="number";
        divRb.appendChild(tb);
        labela = document.createElement("label");
        labela.innerHTML="GB";
        divRb.appendChild(labela);
        kontForma.appendChild(divRb);

        divRb=document.createElement("div");
        let selStorage=document.createElement("select");
        labela = document.createElement("label");
        labela.innerHTML="Vrsta uredjaja:";
        divRb.appendChild(labela);
        divRb.appendChild(selStorage);

        let tipoviStorage=["SATA","M.2 NVME"];

        tipoviStorage.forEach(element => {
            opcija=document.createElement("option");
            opcija.innerHTML=element;
            opcija.value=element;
            selStorage.appendChild(opcija);
        });

        kontForma.appendChild(divRb);

        divRb=document.createElement("div");
        let selCase=document.createElement("select");
        labela = document.createElement("label");
        labela.innerHTML="Kuciste:";
        divRb.appendChild(labela);
        divRb.appendChild(selCase);

        let tipoviCase=["Corsair iCUE 220T RGB","NZXT H400i","Cooler Master Cosmos C700M","Fractal Design Meshify C"];

        tipoviCase.forEach(element => {
            opcija=document.createElement("option");
            opcija.innerHTML=element;
            opcija.value=element;
            selCase.appendChild(opcija);
        });

        kontForma.appendChild(divRb);

        divRb=document.createElement("div");
        elLabela = document.createElement("label");
        elLabela.innerHTML="Napajanje:";
        divRb.appendChild(elLabela);

        tb = document.createElement("input");
        tb.className="napajanje";
        divRb.appendChild(tb);
        kontForma.appendChild(divRb);

        divRb=document.createElement("div");
        elLabela = document.createElement("label");
        elLabela.innerHTML="Cena:";
        divRb.appendChild(elLabela);

        tb = document.createElement("input");
        tb.className="cena";
        divRb.appendChild(tb);
        kontForma.appendChild(divRb);

        divRb=document.createElement("div");
        let selPoz = document.createElement("select");
        labela = document.createElement("label");
        labela.innerHTML="Pozicija";
        divRb.appendChild(labela);
        divRb.appendChild(selPoz);
        for(let i=0;i<this.n;i++)
        {
            opcija=document.createElement("option");
            opcija.innerHTML=i;
            opcija.value=i;
            selPoz.appendChild(opcija);
        }
        kontForma.appendChild(divRb);

        const dugme =  document.createElement("button");
        dugme.innerHTML="Dodaj Racunar";
        kontForma.appendChild(dugme);

        dugme.onclick=(ev)=>{

            const ime = this.kontejner.querySelector(".ime").value;
            const maticna = this.kontejner.querySelector(`input[name='${this.naziv}']:checked`);
            const cpu = selProc.value;
            if(maticna==null)
                alert("Izaberi plocu");
            //if(((maticna.value == "B550" || maticna.value == "X570") && cpu.charAt(0)!="R")||((maticna.value == "B460" || maticna.value == "Z490") && cpu.charAt(0)!="I"))
            //    alert("Ploca ne podrzava procesor"); //sredi alerts, dodaj ukloni i uredi i pomeri provere na server
            //console.log("test cpu");
            const ramKolicina = parseInt(selRamNumber.value);
            const ramVelicina = parseInt(selRamSize.value);
            //if((maticna.value == "B550" || maticna.value == "B460") && ramVelicina==32 && ramKolicina>2)
            //    alert("Ploca ne podrzava ovu konfiguraciju ram memorije")
            //console.log("test ploca");
            const graficka = selGPU.value;
            const storageSize = parseInt(this.kontejner.querySelector(".storage").value);
            const storageType = selStorage.value;
            const kuciste = selCase.value;
            const napajanje = this.kontejner.querySelector(".napajanje").value;
            const cena = this.kontejner.querySelector(".cena").value;
            const poz = parseInt(selPoz.value);
            if(napajanje == "" || cena=="" || ime=="")
                alert("Postoji prazno polje");
            else if(storageSize==0)
                alert("Ne postoji hdd/ssd");
            else if(this.racunari[poz].name == "Prazno"){
                //this.racunari[poz].azurirajRacunar(poz,ime,maticna.value,cpu,ramKolicina,ramVelicina,graficka,storageSize,storageType,kuciste,napajanje,cena);//prebaci preveru na server
                var arrayMemory = [];
                for(let i=0;i<ramKolicina;i++){
                    arrayMemory.push({ size: ramVelicina,
                    type: "RAM" });
                }
                if(storageType=="SATA")
                arrayMemory.push({ size:storageSize,
                    type: "SATA"});
                else
                arrayMemory.push({ size:storageSize,
                    type: "NVME"});
                fetch("https://localhost:5001/PCShop/UpisRacunara/" + this.id,{
                    method:"POST",
                    headers:{
                        "Content-Type": "application/json"
                    },
                    body:JSON.stringify({
                        poz:poz,
                        name:ime,
                        motherboard:{
                            maticna:maticna.value,
                            cpu:cpu,
                            gpu:graficka,
                            maxRam:64,
                            ramSlots:4,
                            maxSATA:4,
                            maxNVME:1,
                            memory: arrayMemory
                        },
                        kuciste:kuciste,
                        psu:napajanje,
                        price:cena
                    })
                }).then(p=>{
                    if(p.ok){
                        this.racunari[poz].azurirajRacunar(poz,ime,maticna.value,cpu,ramKolicina,ramVelicina,graficka,storageSize,storageType,kuciste,napajanje,cena);
                    }
                    else if(p.status==400){
                        const greska={poruka:0};
                        p.json().then(q=>{
                            greska.poruka=q.poruka;
                            alert(greska.poruka);
                        });                        
                    }
                });
            }
            else
                alert("Na ovom mestu postoji racunar");

        }
    }

    crtajUrediUkloni(host)
    {
        const kontUrediUkloni = document.createElement("div");
        kontUrediUkloni.className="kontUrediUkloni";
        host.appendChild(kontUrediUkloni);

        var elLabela = document.createElement("h3");
        elLabela.innerHTML="Uredjenje Postojecih Racunara";
        kontUrediUkloni.appendChild(elLabela);

        let divRb=null;
        let opcija=null;
        let labela=null;

        divRb=document.createElement("div");
        let selUrediRamNumber=document.createElement("select");
        let selUrediRamSize=document.createElement("select");
        labela = document.createElement("label");
        labela.innerHTML="Ram:";
        divRb.appendChild(labela);
        divRb.appendChild(selUrediRamNumber);
        labela = document.createElement("label");
        labela.innerHTML="x";
        divRb.appendChild(labela);
        divRb.appendChild(selUrediRamSize);

        for(let i=0;i<=3;i++)
        {
            opcija=document.createElement("option");
            opcija.innerHTML=i;
            opcija.value=i;
            selUrediRamNumber.appendChild(opcija);
        }
        for(let i=4;i<=32;i=i*2)
        {
            opcija=document.createElement("option");
            opcija.innerHTML=i+"GB";
            opcija.value=i;
            selUrediRamSize.appendChild(opcija);
        }
        kontUrediUkloni.appendChild(divRb);


        divRb=document.createElement("div");
        labela = document.createElement("label");
        labela.innerHTML="HDD/SDD:";
        divRb.appendChild(labela);
        let tb=document.createElement("input");
        tb.className="storageUredi";
        tb.type="number";
        tb.value=0;
        divRb.appendChild(tb);
        labela = document.createElement("label");
        labela.innerHTML="GB";
        divRb.appendChild(labela);
        kontUrediUkloni.appendChild(divRb);

        divRb=document.createElement("div");
        let selUrediStorage=document.createElement("select");
        labela = document.createElement("label");
        labela.innerHTML="Vrsta uredjaja:";
        divRb.appendChild(labela);
        divRb.appendChild(selUrediStorage);

        let tipoviStorage=["SATA","NVME"];

        tipoviStorage.forEach(element => {
            opcija=document.createElement("option");
            opcija.innerHTML=element;
            opcija.value=element;
            selUrediStorage.appendChild(opcija);
        });

        kontUrediUkloni.appendChild(divRb);

        divRb=document.createElement("div");
        let selUrediPoz = document.createElement("select");
        labela = document.createElement("label");
        labela.innerHTML="Pozicija";
        divRb.appendChild(labela);
        divRb.appendChild(selUrediPoz);
        for(let i=0;i<this.n;i++)
        {
            opcija=document.createElement("option");
            opcija.innerHTML=i;
            opcija.value=i;
            selUrediPoz.appendChild(opcija);
        }
        kontUrediUkloni.appendChild(divRb);

        const dugmeUredi =  document.createElement("button");
        dugmeUredi.innerHTML="Uredi Racunar";
        kontUrediUkloni.appendChild(dugmeUredi);

        dugmeUredi.onclick=(ev)=>{

            const ramKolicina = parseInt(selUrediRamNumber.value);
            const ramVelicina = parseInt(selUrediRamSize.value);
            const storageSize = parseInt(this.kontejner.querySelector(".storageUredi").value);
            const storageType = selUrediStorage.value;
            let poz = parseInt(selUrediPoz.value);
            if(this.racunari[poz].name == "Prazno"){
                alert("Na ovom mestu ne postoji racunar");
            }
            else{
                var arrayMemory=[];
                this.racunari[poz].motherboard.RAM.forEach(element => {
                    arrayMemory.push({ size: element.size,
                        type: "RAM" });
                });
                this.racunari[poz].motherboard.SATA.forEach(element => {
                    arrayMemory.push({ size: element.size,
                        type: "SATA" });
                });
                this.racunari[poz].motherboard.NVME.forEach(element => {
                    arrayMemory.push({ size: element.size,
                        type: "NVME" });
                });
                for(let i=0;i<ramKolicina;i++){
                    arrayMemory.push({ size: ramVelicina,
                    type: "RAM" });
                }
                if(storageType=="SATA" && storageSize!=0){
                arrayMemory.push({ size:storageSize,
                    type: "SATA"});
                }
                if(storageType=="NVME" && storageSize!=0){
                arrayMemory.push({ size:storageSize,
                    type: "NVME"});
                }
                fetch("https://localhost:5001/PCShop/UrediMemory/" + this.id+"/"+poz,{
                    method:"POST",
                    headers:{
                        "Content-Type": "application/json"
                    },
                    body:JSON.stringify({
                        poz:poz,
                        name:this.racunari[poz].name,
                        motherboard:{
                            maticna:this.racunari[poz].motherboard.maticna,
                            cpu:this.racunari[poz].motherboard.cpu,
                            gpu:this.racunari[poz].motherboard.GPU,
                            maxRam:this.racunari[poz].motherboard.maxRam,
                            ramSlots:this.racunari[poz].motherboard.ramSlots,
                            maxSATA:this.racunari[poz].motherboard.maxSATA,
                            maxNVME:this.racunari[poz].motherboard.maxNVME,
                            memory: arrayMemory
                        },
                        kuciste:this.racunari[poz].kuciste,
                        psu:this.racunari[poz].psu,
                        price:this.racunari[poz].price
                    })
                }).then(p=>{
                    if(p.ok){
                        if(ramKolicina!=0){
                            this.racunari[poz].azurirajRam(ramKolicina,ramVelicina);
                        }
                        if(storageSize!=0){
                            this.racunari[poz].azurirajStorage(storageSize,storageType);
                        }
                        this.racunari[poz].azurirajText();
                    }
                    else if(p.status==400){
                        const greska={poruka:0};
                        p.json().then(q=>{
                            greska.poruka=q.poruka;
                            alert(greska.poruka);
                        });                        
                    }
                });
                
            }
        }

        const dugmeUkloni =  document.createElement("button");
        dugmeUkloni.innerHTML="Ukloni Racunar";
        kontUrediUkloni.appendChild(dugmeUkloni);
        dugmeUkloni.onclick=(ev)=>{
            let poz = parseInt(selUrediPoz.value);
            if(this.racunari[poz].name == "Prazno"){
                alert("Na ovom mestu ne postoji racunar");
            }
            else{
                let pc;
                pc = new PC("","Prazno","","","","","","","","","","");
                this.racunari[poz].zameniPraznim();
                pc.miniKontejner=this.racunari[poz].miniKontejner;
                this.racunari[poz]=pc;
                fetch("https://localhost:5001/PCShop/IzbrisiRacunar/" + this.id+"/"+poz,{
                    method:"DELETE"
                });
            }
        }
    }

    crtajRacunare(host){
        const kontRacunariLabel = document.createElement("div");
        kontRacunariLabel.className = "kontRacunariLabel";
        const kontRacunari = document.createElement("div");
        kontRacunari.className = "kontRacunari";
        host.appendChild(kontRacunariLabel);
        var elLabela = document.createElement("h3");
        elLabela.className="nazivWarehouse";
        elLabela.innerHTML=this.naziv;
        kontRacunariLabel.appendChild(elLabela);
        kontRacunariLabel.appendChild(kontRacunari);
        let pc;
        for(let i=0;i<this.n;i++)
        {
            pc = new PC("","Prazno","","","","","","","","","","");
            this.dodajRacunar(pc);
            pc.crtajRacunar(kontRacunari);
        }


    }
}