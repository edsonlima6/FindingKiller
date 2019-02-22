$( ).ready(function() {



GetStringTD();


SendAnswer();




});

function GetStringTD(){

    var td = " <th > 1 </th> <td> Mark </td> <td> Otto </td>";
    $("#tableKiller tbody").html(td);


}

function SendAnswer(){

var Investigador = new Object();
Investigador.Local = 0;
Investigador.Suspect = 1;
Investigador.Gun = 2;


console.log(Investigador);

   $("#btnSend").click(function(){
   var url = "/Home/GetSuspect";
   $.post( url, Investigador, function( data ) { console.log(data)});
  });
                                    

}
