(function () {
    var $imagesGridWaitingForUpload = $('.grid').masonry({
        itemSelector: ".grid__item",
        columnWidth: ".grid__sizer",
        gutter: ".gutter__sizer",
        percentPosition: true
    });

    function addImagesToGrid(input) {
        for (var i = 0; i < input.files.length; i++) {
           var file = input.files[i];
           var reader = new FileReader();

           reader.onload = function (e) {
                var el = $('<img />')
                            .attr('src', e.target.result)
                            .attr('class', 'grid__item grid__sizer')
                
               $imagesGridWaitingForUpload
                    .append(el)
                    .masonry('appended', el)
                    .masonry();
           }

           reader.readAsDataURL(file);
        }
    }

    $("#imgInp").change(function () {
        addImagesToGrid(this);
    });
})();

