﻿// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function AddToCart(movieId) {

    $.ajax({

        type: 'post',

        url: '/ShoppingCart/AddToCart',

        dataType: 'json',

        data: { id: movieId },
        success: function (count) {
            console.log(count);
            $('#cartCount').html(count); // The id ‘cartCount’ refers to an HTML-element
        }
    })
}

function IncreaseCopy(movieId) {
    var copyid = 'changecopies' + movieId;
    var subtotalid = "changesubtotal" + movieId;
    var priceid = "changeprice" + movieId;
    var cartcount = Number(document.getElementById('cartCount').innerHTML);
    var totalid = Number(document.getElementById('totalid').innerHTML);
    var oldcopies = Number(document.getElementById(copyid).innerHTML);
    var price = Number(document.getElementById(priceid).innerHTML);
    var newcopies = oldcopies + 1;
    document.getElementById(copyid).innerText = newcopies;
    document.getElementById(subtotalid).innerText = newcopies * price;
    document.getElementById('totalid').innerText = totalid + price;
    document.getElementById('cartCount').innerText = cartcount + 1;

}

function DecreaseCopy(movieId) {
    var copyid = 'changecopies' + movieId;
    var subtotalid = "changesubtotal" + movieId;
    var priceid = "changeprice" + movieId;
    var cartcount = Number(document.getElementById('cartCount').innerHTML);
    var totalid = Number(document.getElementById('totalid').innerHTML);
    var rowid = "row" + movieId;
    var oldcopies = Number(document.getElementById(copyid).innerHTML);
    var price = Number(document.getElementById(priceid).innerHTML);
    var newcopies = oldcopies - 1;
    document.getElementById('cartCount').innerText = cartcount - 1;
    if (newcopies == 0) {
        document.getElementById(rowid).remove();
        document.getElementById('totalid').innerText = totalid - price;
    }
    else {
        document.getElementById(copyid).innerText = newcopies;
        document.getElementById(subtotalid).innerText = newcopies * price;
        document.getElementById('totalid').innerText = totalid - price;
    }

}

function getcustomeremail() {
    var email = document.getElementById('customerEmail').innerHTML;
    console.log(email);
    $.ajax({
        url: '/Cart/Checkout',
        data: { emailid: email },
        type: 'POST',
        success: function (emailid) {
            alert("checked out");
        }
    });
}