var menu = document.querySelector(".contextual");
var listview = document.querySelector(".listview");

if (listview) {

    document.addEventListener("click", function (event) {
        if (event.target.className == "submenu") {
            event.target.parentNode.appendChild(menu);
            if (event.target.dataset.id) {
                setId(event.target.dataset.id);
            }
            menu.style.display = "block";
        }
        else {
            menu.style.display = "none";
        }
    });

    function setId(id) {
        var enlaces = menu.querySelectorAll("a");

        enlaces.forEach(x => {
            x.href = updateQueryStringParameter(x.href, "id", id);
        });


    }

    function updateQueryStringParameter(uri, key, value) {
        var re = new RegExp("([?&])" + key + "=.*?(&|$)", "i");
        var separator = uri.indexOf('?') !== -1 ? "&" : "?";
        if (uri.match(re)) {
            return uri.replace(re, '$1' + key + "=" + value + '$2');
        }
        else {
            return uri + separator + key + "=" + value;
        }
    }
}