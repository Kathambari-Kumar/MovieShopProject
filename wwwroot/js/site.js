// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function AddToCart(movieId) {

    $.ajax({

        type: 'post',

        url: '/Cart/AddToCart',

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
    var totalid = Number(document.getElementById("totalid").innerHTML);
    var oldcopies = Number(document.getElementById(copyid).innerHTML);
    var price = Number(document.getElementById(priceid).innerHTML);
    var newcopies = oldcopies + 1;
    document.getElementById(copyid).innerText = newcopies;
    document.getElementById(subtotalid).innerText = newcopies * price;
    document.getElementById("totalid").innerText = totalid + price;
    document.getElementById('cartCount').innerText = cartcount + 1;
    $.ajax({
        url: '/Cart/AddItem',
        data: { movieId: movieId },
        type: 'POST',
        success: function (movieId) {
            console.log("added");
        }
    });
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
    $.ajax({
        url: '/Cart/ReduceItem',
        data: { movieId: movieId },
        type: 'POST',
        success: function (movieId) {
            console.log("decraesed");
        }
    });
}

function yesfunction() {
    var addr = document.forms["createform"]["billingaddr"].value;
    var zip = document.forms["createform"]["billingzip"].value;
    var city = document.forms["createform"]["billingcity"].value;
    document.forms["createform"]["deliveryaddr"].value = addr;
    document.forms["createform"]["deliveryzip"].value = zip;
    document.forms["createform"]["deliverycity"].value = city;
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