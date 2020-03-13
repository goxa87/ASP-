$(document).ready(function () {
    // Ajax запрос.
    function ajaxRequest(id, ty) {
        return $.ajax({
            url: 'http://www.petrovblog.site//Blog/MakeLike/',
            type: 'get',
            data: {
                postId: id,
                type: ty
            }
        });
    }
    // Нажатие на ссылку Лайкнуть.
    $('.work-like').click(function (event) {
        event.preventDefault();
        // Родитель.
        var parent = $(this).parents('.work-bottom-bar');
        // Параметр id.
        var postId = $(parent).children('.like-id').val();
        // Параметр типа записи.
        var type = $(parent).children('.like-type').val();
        var button = $(this);
        $.when(
            ajaxRequest(postId, type)
                .then(function (resp)
                {
                    // Помещаем ответ в тело вместо старого.
                    $(button).html(resp);
                    // удаляем стиль чтоб нельзя было нажать 2й раз.
                    $(button).removeClass('work-like');
                })
        )
    });
});


