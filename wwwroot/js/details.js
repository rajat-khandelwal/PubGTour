
var tablebody = '#tablebody';
var Id = '#Id';
function Fetchplayers() {
   
    $.ajax({
        url: UrlArray.GetJoinedPlayers,
        type: "post",
        data: { id: $(Id).val() },
        success: function (data) {
            var html = '';
            $.each(data, function (key, val)
            {
                console.log(val);
                html = '<tr><td scope = "row" > #' + (key+1)+'</td><td>' + val.userName+'</td><td>' + val.country+'</td></tr>';
                console.log(html);
                $(tablebody).append(html);

            });

        },
        error: function () {
        
        }

    });

}

$(document).ready(function () {

    Fetchplayers()
});