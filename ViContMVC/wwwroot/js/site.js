// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    $('.plot-btn').on('click', function() {
        $.ajax({
            type: 'POST',
            url: '@Url.Action("NewPlot", "Home")',
            contentType: false,
            processData: false,
            cache: false,
            success: function (res) {
                $('#tester').html(res);
            }
        });
    });
});

