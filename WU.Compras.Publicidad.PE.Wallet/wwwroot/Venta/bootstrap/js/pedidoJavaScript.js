//$(document).ready(function () {
//    ContadortempPedidos();

//});

function SetupControl() {
    $(".btnAgregarProducto").on("click", GetProducto);
    $(".btlDetalle").on("click", validarPedido);

}

function GetProducto() {
    debugger;
    var obj = this;
    //////////////Retornamos un arreglo
    var productoStore = localStorage.getItem("productolst"); //recuperamos lo que esta guardado en la session array
    if (productoStore === null) {
        var productoStore = [];
    }
    else {
        productoStore = JSON.parse(productoStore);
    }

    if (obj !== null) {
        var producto1 ={
            nombre : obj.attributes.Nombre.value,
            Token: obj.attributes.codigo.value,
            Stock : obj.attributes.Stock.value,
            URL : obj.attributes.rutafoto.value,
            //fechaexpiracion : obj.attributes.fechaexpiracion.value,
            //fechaproduccion : obj.attributes.fechaproduccion.value,
        }
        productoStore.push(producto1);
        localStorage.setItem("productolst", JSON.stringify(productoStore));
        toastr.success("El producto " +
                 producto1.nombre + " se agregó correctamente", "Confirmación");
    }


    //Pintamos
    //var ElementoPinta =
    document.getElementById('' + obj.attributes.codigo.value + '').style.color = '#880e4f';
    document.getElementById('' + obj.attributes.codigo.value + '').innerHTML = 'Agregado';

    ContadortempPedidos();

}

function ContadortempPedidos() {
    debugger;

    var CantidadPedidos = localStorage.getItem("productolst");
    if (CantidadPedidos !== null) {

        var ProductoRenew = JSON.parse(CantidadPedidos);

        if (ProductoRenew.length > 0) {

            document.getElementById("ContadorCarrito").innerHTML = ProductoRenew.length;

        }
        else {
            document.getElementById("ContadorCarrito").innerHTML = 0;
        }
    }

}
function validarPedido() {
    debugger;
    var CantidadPedidos = localStorage.getItem("productolst");
    if (CantidadPedidos !== null) {
        debugger;
        var objeCarrtito = JSON.parse(CantidadPedidos);

        if (objeCarrtito.length > 0) {
            var Tokenarray = [];
            $.post("/Producto/VerDetalleCompra",
                { objeCarrtito: JSON.stringify(objeCarrtito) },
                 function (data, status) {
                     //'data', data);

                     debugger;
              
                     var DatGet = JSON.parse(data);
                     var Objt = new Object
                     Objt = DatGet;
                     console.log(Objt.Result[0].IdPedido);
                     console.log(Objt.Result[0].Codigo);
                     console.log(Objt.length);
                     //getTableFromData.length, getTableFromData[0].Nombre);
                     //console.table(getTableFromData)
                     //Armar PopUp
                     var Divbase = 
                     //"<div class=\"container\">" +
                     "  <form asp-action=\"GenerarPedido\"><h3>Detalle de la compra</h3>" +
                     " <table  class=\"table\">"+
                     " <tr>"+
                     " <th>Numeracion</th>"+
                     "<th>Nombre</th>" +
                     " <th>Precio($)</th>" +
                     "<th>Total IGV</th>" +
                     " <th>Cantidad </th>" +
                     " <th>Estado </th>" +
                     "  <th>Fecha Producción </th>" +
                     " <th>Fecha de expiración </th>  </tr>";
                     //</div>";
                     for (var i = 0; i < Objt.Result.length; i++)
                     {
                         Divbase = Divbase +
                       "<tr>"+
                       " <td>" + i + "</td>" +
                       "<td>" +Objt.Result[i].Nombre+ "</td>" +
                       " <td>" +Objt.Result[i].Total + "</td>" +
                       "<td>" +Objt.Result[i].TotalIGV + "</td>" +
                       " <td>" + Objt.Result[i].Cantidad + " </td>" +
                       " <td>" + Objt.Result[i].respuesta+ "</td>" +
                       "  <td>" + Objt.Result[i].fechaproduccion+ " </td>" +
                       " <td>" +Objt.Result[i].fechaexpiracion + "</td>  </tr>";
                         Tokenarray.push(Objt.Result[i].Token)
                     }
                     Divbase = Divbase + "</table> </br>  <input type\"button btn-primary\" class= \"btn\" /> </form>";
                     sessionStorage["lstTokenKey"] = JSON.stringify(Tokenarray);
                     PopUpPedido(Divbase);
                 }

                );
         
        }
    }
  
}
function PopUpPedido(Divbase)
{
    debugger;
    $("#WindowsDetallePedido").html(Divbase);
    var PedidoPopUp = $("#WindowsDetallePedido"),
         btnOpenPedido = $(".btlDetalle");
    btnOpenPedido.click(function () {
        PedidoPopUp.data("KendoWindow").open();
        btnOpenPedido.fadeOut();
    });
    function onClose() {
        debugger;
        btnOpenPedido.fadeIn();

    }
    PedidoPopUp.kendoWindow({
        width: "780px",
        height: "300px",
        visible: false,
        close: onClose
    }).data("kendoWindow").center().open();



}


SetupControl();