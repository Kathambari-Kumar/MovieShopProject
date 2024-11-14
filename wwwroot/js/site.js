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
                console.log(count);
                $('#cartCount').html(count); // The id ‘cartCount’ refers to an HTML-element
            }
        })
    }


//function IncreaseCopy(noofcopies) {

//    $.ajax({

//        type: 'post',

//        url: '/ShoppingCart/IncreaseCount',

//        dataType: 'json',

//        data: { noofcopies: noofcopies },
//        success: function (copies) {
//            console.log("no",copies);
//            $('#increasecopies').html(copies); // The id ‘cartCount’ refers to an HTML-element

//        }
//    })
//}
function IncreaseCopy() {
    var oldcopies = Number(document.getElementById('uniqueid').innerHTML);
    var price = Number(document.getElementById('price').innerHTML);
    var newcopies = oldcopies + 1;
    document.getElementById('uniqueid').innerText = newcopies;
    document.getElementById("total").innerText = newcopies * price;
}

function DecreaseCopy() {
    var oldcopies = Number(document.getElementById('changecopies').innerHTML);
    var price = Number(document.getElementById('price').innerHTML);
    var newcopies = oldcopies - 1;
    document.getElementById("changecopies").innerText = newcopies;
    document.getElementById("total").innerText = newcopies * price;
}

function CartCount()
{
    var numberofitems = Number(document.getElementById('cartCount').innerHTML);
    
    document.getElementById("increasecopies").innerText = numberofitems;
}