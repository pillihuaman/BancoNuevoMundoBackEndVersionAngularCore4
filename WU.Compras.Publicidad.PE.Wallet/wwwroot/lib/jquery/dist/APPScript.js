$(document).ready(function () {

    //alert("Api Base 01");
    var option = "<option value='0'>Select</option>";
    //$("#IdDepartamento").html(option);
    $("#IdProvincia").html(option);
    $("#IdDepartamento").change(function ()
    {
     
        var IdDepartamento = "#IdDepartamento";

        var url = "http://localhost:7609/Afiliacion/Lista_Provincia";
        $.getJSON(
            url,
               { IdDepartamento: $(IdDepartamento).val() },
               function (data)
               {
                   var item = '';
                   $("#IdProvincia").empty();
                   $.each(data, function (i, IdProvincia) {
                       item += "<option value='" + IdProvincia.value + "'>" + IdProvincia.text + "</option>";
                     
                    
                   });

                   $("#IdProvincia").html(item);
               });

    });
    $("#IdProvincia").change(function () {

        var IdDepartamento = "#IdDepartamento";
        var IdProvincia = "#IdProvincia";

        var url = "http://localhost:7609/Afiliacion/Lista_Distrito";
        $.getJSON(
            url,
               { IdDepartamento: $(IdDepartamento).val(), IdProvincia: $(IdProvincia).val() },
               function (data) {
                   var item = '';
                   $("#IdDistrito").empty();

                   $.each(data, function (i, IdDistrito) {
                       item += "<option value='" + IdDistrito.value + "'>" + IdDistrito.text + "</option>";


                   });

                   $("#IdDistrito").html(item);
               });

    });


});