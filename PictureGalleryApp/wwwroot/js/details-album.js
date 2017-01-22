(function () {
    var $grid = $('.grid').masonry({
        itemSelector: ".grid__item",
        columnWidth: ".grid__sizer",
        gutter: ".gutter__sizer",
        percentPosition: true
    });

    $(window).on("load", function () {
        $grid.masonry('layout');
    });

    // Image replacement handler
    $(document).on("click", ".js-button", function () {
        var imageSrc = $(this).parents(".grid__item").find("img").attr("src");
        var imageId = $(this).parents(".grid__item").find("img").attr("picture-id");
        $(".js-download").attr("href", imageSrc);
        $(".js-modal-image").attr("src", imageSrc);
        $("#selected-picture-id").attr("value", imageId);
        $(".comments-list").empty();

        $.ajax("../../Comment/Index?pictureId=" + imageId, {
            success: function (data) {
                $(".comments-list").html(data);
            },
            error: function () {

            }
        });

        $(document).on("click", ".js-heart", function () {
            $(this).toggleClass("active");
        });
    });
})();