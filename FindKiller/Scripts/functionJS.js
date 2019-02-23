$( ).ready(function() {
    ComponentMask();
    SendAnswer();
});

function GetStringTD(data) {
  var hid =  '<tr class="d-none"> \
                <th> <input type="hidden" id="SuspectId" value="{0}" /> </th> \
                <td> <input type="hidden" id="LocalId" value="{1}" /> </td> \
                <td> <input type="hidden" id="GunId" value="{2}" /> </td> \
              </tr> \
                < tr > \
                 <th id="nameSuspect"> {3} </th> \
                 <td id="nameLocal"> {4} </td> \
                 <td id="nameGun"> {5} </td> \
              </tr>'

    hid = hid.replace("{0}", data.Suspect.SuspectId).replace("{1}",  data.Local.LocalId).replace("{2}",  data.Gun.GunId);
    hid = hid.replace("{3}", data.Suspect.Name).replace("{4}", data.Local.Name).replace("{5}", data.Gun.Name);

    $("#tableKiller tbody").html(hid);


    if (data.pLocal == "0") {

        $("#btnSend").attr("disabled","disabled");
        $("#exampleModal").modal("toggle");  
    }

}

function SendAnswer(){


    $("#btnSend").click(function () {

        var result = $("#informaSuspect").val();
        if (result >= 0 && result < 4) {

            var inv = new Investigador(result);
            inv.Local.LocalId = $("#LocalId").val();
            inv.Local.Name = $("#nameLocal").text();
            inv.Gun.GunId = $("#GunId").val();
            inv.Gun.Name = $("#nameGun").text();
            inv.Suspect.SuspectId = $("#SuspectId").val();
            inv.Suspect.Name = $("#nameSuspect").text();
            PostRequest(inv);         
        }
        else
            alert("Por favor digitar um numero entre 0 e 3.");
  
      });
                                    

}

function PostRequest(inv) {
    if (inv == null)
        var inv = new Investigador(null);

    var url = "/Home/GetSuspect";
    $.post(url, inv, function (data) {
 
        GetStringTD(data);
    });
}

function ComponentMask() {
    $("#informaSuspect").mask("0,0,0");
}


function Investigador(local) {
    this.pLocal = local;
    this.Local = new Object();
    this.Gun = new Object();
    this.Suspect = new Object();
}