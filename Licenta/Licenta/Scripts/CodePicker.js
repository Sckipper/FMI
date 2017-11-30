var CodePicker = function () {

    var elements = {
        codePickerDiv: $("#CodePickerDiv"),
        canvas: $("#canvas"),
        canvas2: $("#canvas2"),
        codePicker: $("#codepicker"),
        categoryId: $("#Category_CategorieID"),
    };

    var Rayons = [];

    var initialize = function () {
        var ctx = elements.canvas[0].getContext("2d");
        ctx.lineWidth = 2;

        var img = new Image(1000, 1000);
        var overlayImg = new Image(1000, 1000);
        img.onload = function () {
            ctx.drawImage(img, 0, 0, 1000, 1000);
        }
        img.src = "/Licenta/Content/Images/ShopSplit.png";

        initializeRayons();
    }

    var initializeRayons = function () {
        var rects = null;

        Rayons.push({
            "id": 1,
            "coords": {
                "startX": 5,
                "startY": 124,
                "endX": 124,
                "endY": 565
            },
            "rafturi": [
                {
                    "startX": 5,
                    "startY": 124,
                    "endX": 124,
                    "endY": 271
                },
                {
                    "startX": 5,
                    "startY": 271,
                    "endX": 124,
                    "endY": 418
                },
                {
                    "startX": 5,
                    "startY": 418,
                    "endX": 124,
                    "endY": 565
                }
            ],
            "aranjament": "vertical",
            "nrRafturi": "3"
        });
        Rayons.push({
            "id": 2,
            "coords": {
                "startX": 334,
                "startY": 180,
                "endX": 430,
                "endY": 585
            },
            "rafturi": [
                {
                    "startX": 334,
                    "startY": 180,
                    "endX": 430,
                    "endY": 281
                },
                {
                    "startX": 334,
                    "startY": 281,
                    "endX": 430,
                    "endY": 382
                },
                {
                    "startX": 334,
                    "startY": 382,
                    "endX": 430,
                    "endY": 483
                },
                {
                    "startX": 334,
                    "startY": 483,
                    "endX": 430,
                    "endY": 584
                }
            ],
            "aranjament": "vertical",
            "nrRafturi": "4"
        });
        Rayons.push(
            {
                "id": 3,
                "coords": {
                    "startX": 5,
                    "startY": 572,
                    "endX": 124,
                    "endY": 985
                },
                "rafturi": [
                    {
                        "startX": 5,
                        "startY": 572,
                        "endX": 124,
                        "endY": 985
                    }
                ],
                "aranjament": "vertical",
                "nrRafturi": "1"
            });
        Rayons.push({
            "id": 4,
            "coords": {
                "startX": 244,
                "startY": 659,
                "endX": 344,
                "endY": 765
            },
            "rafturi": [
                {
                    "startX": 244,
                    "startY": 659,
                    "endX": 344,
                    "endY": 765
                }
            ],
            "aranjament": "vertical",
            "nrRafturi": "1"
        });
        Rayons.push({
            "id": 5,
            "coords": {
                "startX": 350,
                "startY": 657,
                "endX": 437,
                "endY": 769
            },
            "rafturi": [
                {
                    "startX": 350,
                    "startY": 657,
                    "endX": 437,
                    "endY": 769
                }
            ],
            "aranjament": "vertical",
            "nrRafturi": "1"
        });
        Rayons.push({
            "id": 6,
            "coords": {
                "startX": 130,
                "startY": 859,
                "endX": 749,
                "endY": 992
            },
            "rafturi": [
                {
                    "startX": 130,
                    "startY": 859,
                    "endX": 336,
                    "endY": 992
                },
                {
                    "startX": 336,
                    "startY": 859,
                    "endX": 542,
                    "endY": 992
                },
                {
                    "startX": 542,
                    "startY": 859,
                    "endX": 748,
                    "endY": 992
                }
            ],
            "aranjament": "horizontal",
            "nrRafturi": "3"
        });
        Rayons.push({
                "id": 7,
                "coords": {
                    "startX": 545,
                    "startY": 657,
                    "endX": 637,
                    "endY": 764
                },
                "rafturi": [
                    {
                        "startX": 545,
                        "startY": 657,
                        "endX": 637,
                        "endY": 764
                    }
                ],
                "aranjament": "vertical",
                "nrRafturi": "1"
            });
        Rayons.push({
            "id": 8,
            "coords": {
                "startX": 644,
                "startY": 657,
                "endX": 732,
                "endY": 765
            },
            "rafturi": [
                {
                    "startX": 644,
                    "startY": 657,
                    "endX": 732,
                    "endY": 765
                }
            ],
            "aranjament": "vertical",
            "nrRafturi": "1"
        });
        Rayons.push({
            "id": 9,
            "coords": {
                "startX": 875,
                "startY": 569,
                "endX": 992,
                "endY": 974
            },
            "rafturi": [
                {
                    "startX": 875,
                    "startY": 569,
                    "endX": 992,
                    "endY": 974
                }
            ],
            "aranjament": "vertical",
            "nrRafturi": "1"
        });
        Rayons.push({
            "id": 10,
            "coords": {
                "startX": 874,
                "startY": 184,
                "endX": 994,
                "endY": 564
            },
            "rafturi": [
                {
                    "startX": 874,
                    "startY": 184,
                    "endX": 994,
                    "endY": 564
                }
            ],
            "aranjament": "vertical",
            "nrRafturi": "1"
        });
        Rayons.push({
            "id": 11,
            "coords": {
                "startX": 504,
                "startY": 180,
                "endX": 584,
                "endY": 587
            },
            "rafturi": [
                {
                    "startX": 504,
                    "startY": 180,
                    "endX": 584,
                    "endY": 383
                },
                {
                    "startX": 504,
                    "startY": 383,
                    "endX": 584,
                    "endY": 586
                }
            ],
            "aranjament": "vertical",
            "nrRafturi": "2"
        });
    };

    elements.codePicker.click(function (event) {
        elements.codePickerDiv.show();
        event.stopPropagation();
    });

    $(window).click(function () {
        if (elements.codePickerDiv.is(":visible"))
            elements.codePickerDiv.hide();
    });

    elements.codePickerDiv.click(function(event){
        event.stopPropagation();
    })

    elements.canvas.click(function (e) {
        pointX = ((e.clientX - elements.canvas2.offset().left) * 1000) / elements.canvas2.width();
        pointY = ((e.clientY - elements.canvas2.offset().top) * 1000) / elements.canvas2.height();

        var ctx = elements.canvas[0].getContext("2d");
        var canvas2 = elements.canvas2[0];
        var ctx2 = canvas2.getContext("2d");

        for (var i = 0; i < Rayons.length; i++) {	//trec prin fiecare raion si verific sa vad unde a dat click
            if (pointX > Rayons[i].coords.startX && pointX < Rayons[i].coords.endX && pointY > Rayons[i].coords.startY && pointY < Rayons[i].coords.endY) {
                ctx.strokeStyle = '#ff0000';
                ctx2.beginPath();		//testing purpose desenez ceva ca sa se vada unde s-a dat click
                ctx2.arc(pointX, pointY, 10, 0, 2 * Math.PI);
                ctx2.stroke();
                for (var j = 0; j < Rayons[i].rafturi.length; j++) {
                    if (pointX > Rayons[i].rafturi[j].startX && pointX < Rayons[i].rafturi[j].endX && pointY > Rayons[i].rafturi[j].startY && pointY < Rayons[i].rafturi[j].endY) {
                        var code = null;
                        if (elements.categoryId.val() != "")
                            code = Rayons[i].id + '-' + (j + 1) + '-' + Rayons[i].nrRafturi;
                        else
                            code = Rayons[i].id
                        //console.log('COD:' + Rayons[i].id + '-' + (j + 1) + '-' + Rayons[i].nrRafturi);
                        elements.codePicker.val(code);
                        elements.codePickerDiv.hide();
                    }
                }
            }
        }
    });



    function splitRectangleInParts(startX, startY, endX, endY, parts, direction) {	//direction means position of the shelf
        var rectangles = [];
        if (direction == 'vertical') {	//in functie de directie calculez distanta si creez noile dreptunghiuri
            var distance = Math.floor(Math.abs(startY - endY) / parts);
            for (var i = 0; i < parts; i++) {
                rectangles.push({ 'startX': startX, 'startY': (startY + (i * distance)), 'endX': endX, 'endY': startY + ((i + 1) * distance) });
            }
        } else {
            var distance = Math.floor(Math.abs(startX - endX) / parts);
            for (var i = 0; i < parts; i++) {
                rectangles.push({ 'startX': (startX + (i * distance)), 'startY': startY, 'endX': startX + ((i + 1) * distance), 'endY': endY });
            }
        }
        return rectangles;
    }

    initialize();

    elements.categoryId.change(function () {
        elements.codePicker.val("");
    });

}
var codpicker = new CodePicker();
