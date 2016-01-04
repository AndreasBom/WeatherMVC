$(function () {
    $('#').autocomplete({
        source: function (request, response) {
            $.ajax({
                url: 'Graph.aspx/GetStationName',
                data: "{ 'stationName':'" + request.term + "'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return { value: item }
                    }));
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert(textStatus + "Ingen station hittades");
                }
            });
        }
    });
});