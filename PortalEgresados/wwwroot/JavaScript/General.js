var menu = document.querySelector(".contextual");

document.addEventListener("click", function (event) {
    if (event.target.tagName == "TD" && event.target.parentNode.children.length - 1 == event.target.cellIndex) {
        event.target.appendChild(menu);
        menu.style.display = "block";
    }
    else if (menu.style.display == "block") {
        menu.style.display = "none";
    }

})