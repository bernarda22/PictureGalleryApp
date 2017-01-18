// Write your Javascript code.
(function () {

    function readURL(input) {
        for (var i = 0; i < input.files.length; i++) {
            var file = input.files[i];
            var reader = new FileReader();

            reader.onload = function (e) {
                $('<img />')
                        .attr('src', e.target.result)
                        .appendTo($('#image-section'));
            }

            reader.readAsDataURL(file);
        }
    }

    $("#imgInp").change(function () {
        readURL(this);
    });
})()