$(function () {
    $('.edit').hide();
    $('.edit-case').on('click', function () {
        var tr = $(this).parents('tr:first');
        tr.find('.edit, .read').toggle();
    });
    $('.update-case').on('click', function (e) {
        e.preventDefault();
        var tr = $(this).parents('tr:first');
        id = $(this).prop('id');
        //var eventId = tr.find('#EventId').val();
        var name = tr.find('#Name').val();
        var oddsForFirstTeam = tr.find('#OddsForFirstTeam').val();
        var oddsForSecondTeam = tr.find('#OddsForSecondTeam').val();
        var oddsForDraw = tr.find('#OddsForDraw').val();
        var eventStartDate = tr.find('#EventStartDate').val();
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "http://localhost:62735/Events/Edit",
            data: JSON.stringify({
                "id": id,
                //"eventId": eventId,
                "name": name,
                //"oddsForFirstTeam": oddsForFirstTeam,
                //"oddsForDraw": oddsForDraw,
                //"oddsForSecondTeam": oddsForSecondTeam,
                //"eventStartDate": eventStartDate
            }),
            dataType: "json",
            success: function (data) {
                tr.find('.edit, .read').toggle();
                $('.edit').hide();
                tr.find('#name').text(data.event.Name);
                //tr.find('#oddsForFirstTeam').text(data.event.OddsForFirstTeam);
                //tr.find('#oddsForDraw').text(data.event.OddsForDraw);
                //tr.find('#oddsForSecondTeam').text(data.event.OddsForSecondTeam);
                //tr.find('#eventStartDate').text(data.event.EventStartDate);
            },
            error: function (err) {
                alert("error");
            }
        });
    });
    $('.cancel-case').on('click', function (e) {
        e.preventDefault();
        var tr = $(this).parents('tr:first');
        var id = $(this).prop('id');
        tr.find('.edit, .read').toggle();
        $('.edit').hide();
    });
    $('.delete-case').on('click', function (e) {
        e.preventDefault();
        var tr = $(this).parents('tr:first');
        id = $(this).prop('id');
        $.ajax({
            type: 'POST',
            contentType: "application/json; charset=utf-8",
            url: "http://localhost:62735/Events/Delete/" + id,
            dataType: "json",
            success: function (data) {
                alert('Delete success');
                window.location.href = "http://localhost:62735/Events/Edit";
            },
            error: function () {
                alert('Error occured during delete.');
            }
        });
    });
});