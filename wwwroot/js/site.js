// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function AddToCart(movieId) {

    $.ajax({

        type: 'post',

        url: '/ShoppingCart/AddToCart',

        dataType: 'json',

        data: { id: movieId },
        success: function (count) {

            $('#cartCount').html(count); // The id ‘cartCount’ refers to an HTML-element

        }

    })
}