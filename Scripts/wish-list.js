var arrWList = [];
var list = "";

function renderWList() {
    const $wList = document.querySelector(".wList");
    arrWList = JSON.parse(window.localStorage.getItem("WISHLIST"));
    if (arrWList != null && arrWList > 0) {
        for (i in arrWList) {
            list += '<tr>' +
                        '<td class="thumbnail-img">' +
                            '<a href="#">' +
                                '<img class="img-fluid" src="~/assest/images/' + arrWList[i].ImageUrl + '" alt="" />' +
                            '</a>'+
                        '</td>'+
                        '<td class="name-pr">'+
                            '<a href="#">' +
                                arrWList[i].Name +
                            '</a>'+
                        '</a>'+
                        '<td class="price-pr">' +
                            '<p>' +'$'+ arrWList[i].Price + '</p>' +
                        '</td>'+
                        '<td class="quantity-box">' + 'In Stock' +'</td>'+
                        '<td class="add-pr">' +
                            '<a class="btn hvr-hover" href="#">' + 'Add to Cart' + '</a>' +
                        '</td>' +
                        '<td class="remove-pr">' +
                            '<a href="#">' +
                                '<i class="fas fa-times">' + '</i>' +
                            '</a>' +
                        '</td>' +
                    '</tr>';
        }
    }
    wList.innerHTML = list;
};
renderWList();

var wishList = [];
$(document).ready(function () {
    if (window.localStorage) {
        wishList = JSON.parse(window.localStorage.getItem("WISHLIST"));
    }
    renderWList();
});

function addWishList(id) {
    var Product = { ID: id, Name: "name", ImageUrl: "Url", Price: "price" };
    var Name = document.getElementById("txtName_" + id).innerHTML;
    var ImageUrl = document.getElementById("txtImageUrl_" + id).src;
    var Price = document.getElementById("txtPrice_" + id).innerHTML;
    Product.Name = Name;
    Product.ImageUrl = ImageUrl;
    Product.Price = Price;
    if (window.localStorage) {
        wishList = JSON.parse(window.localStorage.getItem("WISHLIST"));
    }
    if (wishList != null && wishList.length > 0) {
        wishList.push(Product);     
    }
    else {
        wishList = [];
        wishList.push(Product);
    }
    window.localStorage.setItem("WISHLIST", JSON.stringify(wishList));
    renderWList();
}