$(document).ready(function () {
    $('#submit').click(function (event) {
        event.preventDefault();
        var valthis = $('#thisval').val();
        $('.rezult').load(@Url.Action("TestPost","Home")+'?t=' + valthis);
    });
});


