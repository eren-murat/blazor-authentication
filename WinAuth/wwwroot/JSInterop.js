function getStyle(element, property) {
    return window.getComputedStyle ? window.getComputedStyle(element, null).getPropertyValue(property) : element.style[property.replace(/-([a-z])/g, function (g) { return g[1].toUpperCase(); })];
}

function init(dotNetObject) {

    var labels = document.getElementsByClassName("item-label");
    var controls = document.getElementsByClassName("item-control");

    [].forEach.call(labels, function (label) {
        //var color = getStyle(label, "background-color");
        //var border = getStyle(label, "border");
        //var fontSize = getStyle(label, "font-size");
        //console.log(label.id + " " + label.offsetWidth + " " + label.offsetHeight + " " + label.offsetTop + " " + label.offsetLeft + " " + color + " " + border + " " + fontSize);

        //dotNetObject.invokeMethodAsync('InitPropertiesLabel', label.id, label.offsetWidth.toString(10), label.offsetHeight.toString(10), label.offsetTop.toString(10), label.offsetLeft.toString(10), color, border, fontSize);
    });

    [].forEach.call(controls, function (control) {
        var color = getStyle(control, "background-color");
        var border = getStyle(control, "border");
        var fontSize = getStyle(control, "font-size");

        // console.log(control.id + " " + control.offsetWidth + " " + control.offsetHeight + " " + control.offsetTop + " " + control.offsetLeft + " " + color + " " + border + " " + fontSize);

        dotNetObject.invokeMethodAsync('InitPropertiesLabel', control.id, control.offsetWidth.toString(10), control.offsetHeight.toString(10), control.offsetTop.toString(10), control.offsetLeft.toString(10), color, border, fontSize);
    });
}

function updateWidth(id, width) {
    var elem = document.getElementById(id);
    elem.style.width = width + "px";
}

function updateHeight(id, height) {
    var elem = document.getElementById(id);
    elem.style.height = height + "px";
}

function updateTop(id, top) {
    var elem = document.getElementById(id);
    elem.style.top = top + "px";
}

function updateLeft(id, left) {
    var elem = document.getElementById(id);
    elem.style.left = left + "px";
}

function updateColor(id, color) {
    var elem = document.getElementById(id);
    elem.style.backgroundColor = color;
}

function updateBorder(id, border) {
    var elem = document.getElementById(id);
    elem.style.border = border;
}

function updateFontSize(id, fontSize) {
    var elem = document.getElementById(id);
    elem.style.fontSize = fontSize;
}

function draggable(dotNetObject) {

    var container = document.getElementById("container");

    var activeItem = null;

    var active = false;

    var type;

    container.addEventListener("click", click, false);
    container.addEventListener("mousedown", dragStart, false);
    container.addEventListener("mouseup", dragEnd, false);
    container.addEventListener("mousemove", drag, false);

    function getStyle(element, property) {
        return window.getComputedStyle ? window.getComputedStyle(element, null).getPropertyValue(property) : element.style[property.replace(/-([a-z])/g, function (g) { return g[1].toUpperCase(); })];
    }

    function sendDetails(id, className, width, height, top, left, color, border, fontSize) {
        dotNetObject.invokeMethodAsync('GetDetails', id, className, width, height, top, left, color, border, fontSize);
    }

    function click(e) {
        if (e.target != e.currentTarget) {
            var item = e.target;


            if (item.className === "item-label" || item.className === "item-control") {

                var backgroundColor = getStyle(item, "background-color");
                var border = getStyle(item, "border");
                var fontSize = getStyle(item, "font-size");

                sendDetails(item.id, item.className, item.offsetWidth.toString(10), item.offsetHeight.toString(10), item.offsetTop.toString(10), item.offsetLeft.toString(10), backgroundColor, border, fontSize);
            }

            if (item.parentElement.className === "item-control") {
                // console.log("###" + item.parentElement + " - " + item.parentElement.className);

                var backgroundColor = getStyle(item.parentElement, "background-color");
                var border = getStyle(item.parentElement, "border");
                var fontSize = getStyle(item.parentElement, "font-size");

                sendDetails(item.parentElement.id, item.parentElement.className, item.parentElement.offsetWidth.toString(10), item.parentElement.offsetHeight.toString(10), item.parentElement.offsetTop.toString(10), item.parentElement.offsetLeft.toString(10), backgroundColor, border, fontSize);
            }
        }

    }

    function dragStart(e) {

        if (e.target !== e.currentTarget) {
            active = true;

            // this is the item we are interacting with
            activeItem = e.target;

            type = e.target.className;
            if (type === "item-label" || type === "item-control" || type === "details") {
                if (activeItem !== null) {

                    if (!activeItem.xOffset) {
                        activeItem.xOffset = 0;
                    }

                    if (!activeItem.yOffset) {
                        activeItem.yOffset = 0;
                    }

                    activeItem.currentX = 0;
                    activeItem.currentY = 0;

                    activeItem.initialX = Math.trunc(activeItem.offsetLeft + activeItem.offsetWidth / 2);
                    activeItem.initialY = Math.trunc(activeItem.offsetTop + activeItem.offsetHeight / 2);

                    activeItem.xOffset = activeItem.initialX - e.clientX;
                    activeItem.yOffset = activeItem.initialY - e.clientY;

                    if (type === "item-label" || type === "item-control") {
                        var backgroundColor = getStyle(activeItem, "background-color");
                        var border = getStyle(activeItem, "border");
                        var fontSize = getStyle(activeItem, "font-size");

                        sendDetails(activeItem.id, activeItem.className, activeItem.offsetWidth.toString(10), activeItem.offsetHeight.toString(10), activeItem.offsetTop.toString(10), activeItem.offsetLeft.toString(10), backgroundColor, border, fontSize);
                        //console.log("drag start");
                    }
                }
            }
        }
    }

    function dragEnd(e) {
        if (activeItem !== null) {

            if (type === "item-label" || type === "item-control" || type === "details") {
                activeItem.initialX = activeItem.currentX;
                activeItem.initialY = activeItem.currentY;

                if (type === "item-label" || type === "item-control") {
                    var backgroundColor = getStyle(activeItem, "background-color");
                    var border = getStyle(activeItem, "border");
                    var fontSize = getStyle(activeItem, "font-size");

                    sendDetails(activeItem.id, activeItem.className, activeItem.offsetWidth.toString(10), activeItem.offsetHeight.toString(10), activeItem.initialY.toString(10), activeItem.initialX.toString(10), backgroundColor, border, fontSize);
                    //console.log("END: " + activeItem.id + " " + activeItem.className + " " + activeItem.offsetWidth + " " + activeItem.offsetHeight + " " + activeItem.initialY + " " + activeItem.initialX);
                }

                if (activeItem.initialY !== undefined && activeItem.initialX !== undefined) {
                    dotNetObject.invokeMethodAsync('SavePosition', activeItem.id.toString(10), activeItem.initialY.toString(10), activeItem.initialX.toString(10), activeItem.className);
                }
            }
        }

        active = false;
        activeItem = null;
    }

    function drag(e) {
        if (active) {

            if (type === "item-label" || type === "item-control" || type === "details") {
                activeItem.currentX = e.clientX - activeItem.initialX + Math.trunc(activeItem.xOffset);
                activeItem.currentY = e.clientY - activeItem.initialY + Math.trunc(activeItem.yOffset);

                // activeItem.xOffset = activeItem.currentX;
                // activeItem.yOffset = activeItem.currentY;

                setTranslate(activeItem.currentX, activeItem.currentY, activeItem);

                //if (type === "item-label" || type === "item-control") {

                //    var backgroundColor = getStyle(activeItem, "background-color");
                //    var border = getStyle(activeItem, "border");
                //    var fontSize = getStyle(activeItem, "font-size");

                //    sendDetails(activeItem.id, activeItem.className, activeItem.offsetWidth.toString(10), activeItem.offsetHeight.toString(10), activeItem.offsetTop.toString(10), activeItem.offsetLeft.toString(10), backgroundColor, border, fontSize);
                //}
            }

        }
    }

    function setTranslate(xPos, yPos, el) {
        el.style.transform = "translate3d(" + xPos + "px, " + yPos + "px, 0)";
    }
}

function resizable() {

    var container = document.getElementById("container");

    var status = false;
    var elem = null;

    container.addEventListener("click", initResize, false);

    var startX, startY, startWidth, startHeight;

    function initResize(e) {
        if (e.target !== e.currentTarget) {

            if (e.target.className == "item") {
                status = true;
                elem = e.target;

                startX = e.clientX;
                startY = e.clientY;
                startWidth = parseInt(document.defaultView.getComputedStyle(elem).width, 10);
                startHeight = parseInt(document.defaultView.getComputedStyle(elem).height, 10);

                var resizer = document.createElement('div');
                resizer.className = 'resizer';
                resizer.style.width = '10px';
                resizer.style.height = '10px';
                resizer.style.background = 'red';
                resizer.style.position = 'absolute';
                resizer.style.right = 0;
                resizer.style.bottom = 0;
                resizer.style.cursor = 'se-resize';
                elem.appendChild(resizer);
                resizer.addEventListener('mousedown', startResize, false);
            }
        }
    }

    function startResize(e) {
        window.addEventListener('mousemove', Resize, false);
        window.addEventListener('mouseup', stopResize, false);
    }

    function Resize(e) {
        if (status) {
            elem.style.width = (startWidth + e.clientX - startX) + 'px';
            elem.style.height = (startHeight + e.clientY - startY) + 'px';
        }
    }

    function stopResize(e) {
        window.removeEventListener('mousemove', Resize, false);
        window.removeEventListener('mouseup', stopResize, false);

        //console.log(elem.lastChild.className);

        elem.removeChild(elem.lastChild);
        status = false;
        elem = null;
    }
}