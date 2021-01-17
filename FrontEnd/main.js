import {Warehouse} from "./warehouse.js"

fetch("https://localhost:5001/PCShop/PreuzmiWarehouses").then(p=>{
    p.json().then(data=>{
        data.forEach(warehouse => {
            const warehouse1 = new Warehouse(warehouse.id,warehouse.naziv,warehouse.n);
            warehouse1.crtajWarehouse(document.body);

            warehouse.racunari.forEach(pc=>{
                var rac = warehouse1.racunari[pc.poz];
                console.log(pc);
                rac.azurirajRacunar2(pc.poz,pc.name,pc.motherboard,pc.kuciste,pc.psu,pc.price);
            })
        });
    })
});



//const warehouse1 = new Warehouse("Warehouse",4);
//warehouse1.crtajWarehouse(document.body);

