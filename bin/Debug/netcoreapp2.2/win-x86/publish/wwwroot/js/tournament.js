$(document).ready(function () {

    FetchTounament()
});

var TournamentList = '#TournamentList';

function FetchTounament() {

    var count = 0;

    $.ajax({
        url: UrlArray.GettounamentList,
        type: "post",
        data: { skp: count },
        success: function (data) {
            count += 10;
            console.log(data);
            var htmp = '';
            $.each(data, function (key, val) {
                var cls = '';

                console.log(val.isjoined);

                var item = ' <div class="card col-lg-12 col-sm-12 py-2">' +
                    '<div class="row no-gutters">' +
                    '<div class="col-auto">' +

                    '<img src="/icons/resize-15722766691823685163pubgthumbnail.jpg" class="img-thumbnailimg-fluid" alt="">' +
                    ' </div>' +
                    ' <div class="col">' +
                    '<div class="card-body">' +
                    '  <div class="float-right text-muted">' + val.date_Time + '</div>' +
                    ' <h4 class="card-title text-muted">' + val.title + '</h4>' +
                    ' <div class="progress">' +
                    '      <div class="progress-bar progress-bar-striped progress-bar-animated text-dark" role="progressbar" aria-valuenow="' + val.avail +'" aria-valuemin="0" aria-valuemax="100" style="width: ' + val.avail +'%">Slots ' + val.avail +'/' + val.slots + '</div>' +
                    '  </div>' +
                    '  <div style="font-size:x-large">' +
                    '    <label class="badge" style="background:#b3d7ff"><i class="fas fa-trophy"></i>' + val.prize + ' <i class="fas fa-rupee-sign"></i></label>' +
                    '   <label class="badge" style="background:#b3d7ff"><i class="fas fa-users"></i>' + val.type + '</label>' +
                    '   <label class="badge alert-light" style="background:#ffc107"><i class="fas fa-user"></i>' + val.avail+'/' + val.slots + '</label>' +
                    '  <div class="p-2 btn-group btn-group-sm float-right" role="group" aria-label="example">' +
                    '       <button type="button"   class="btn btn-secondary">Detail</button>';
                if (!val.isjoined) {
                    item += '<button type="button" OnClick=javascript:location.replace("/Payment/startpayment/' + val.tourId + '")  class="btn btn-success">Join</button>';
                }
                else {
                    item += '<button type="button"  class="btn btn-success disabled">Joined</button>';

                }

                item +=   '   </div>' +
                    '   </div>' +
                    '</div>' +
                    ' </div>' +
                    '</div>' +
                    ' </div>"';

                $(TournamentList).append(item);

            });        


          
        },
        error: function ()
        {

        }

    });

}