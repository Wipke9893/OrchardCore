// Correct content of promoCode.js
document.getElementById("wholesaleLink").addEventListener("click", function() {
    var promoContainer = document.getElementById("promoCodeContainer");
    if (promoContainer.style.display === "none") {
        promoContainer.style.display = "block";
    } else {
        promoContainer.style.display = "none";
    }
});

function submitPromoCode() {
    var enteredCode = document.getElementById("promoCodeInput").value;
    if (enteredCode === "HallsCreek01") {
        window.location.href = "/HallsCreekTreeFarm/HallsCreekCatalogWholeSale"; // Redirect to Wholesale Catalog
    } else {
        alert("Invalid Promo Code.");
    }
}
