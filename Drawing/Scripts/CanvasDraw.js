/// <reference path="_references.js" />

$(function () {
    var strokeWidth = 5, strokeColor = 'black';

    var FREE = 0, LINE = 1, RECT = 2, FILLRECT = 3, OVAL = 4, FILLOVAL = 5, ERASE = 6, NONE = 7;
    var command = FREE;

    function initColorButton() {
        var identifier = '#' + strokeCollor.toString() + 'Button';

        $(identifier).addClass('selectedButton');
        //Changes the placeholder icon which displays current color.
        $('#currentColor').css('background-color', strokeColor);
    }

    function initCommandButton() {
        var identifier;
        switch (command) {
            case FREE:
                identifier = '#freeCommand';
                break;
            case RECT:
                identifier = '#lineCommand';
                break;
            case FILLRECT:
                identifier = '#fillRectCommand';
                break;
            case OVAL:
                identifier = '#ovalCommand';
                break;
            case FILLOVAL:
                identifier = '#fillOvalCommand';
                break;
            case ERASE:
                identifier = '#eraseCommand';
                break;
        }
        $(identifier).addClass('selectedButton');
    }

    initColorBtn();
    initCommandBtn();

    //changes the coor based on the button pressed.
    $('.colorButton').on('click', function () {
        strokeColor = $(this).css('background-color');

        //All other selected colors are deselected.
        $(this).parent().children().not(this).removeClass('selectedButton');
        $(this).addClass('selectedButton');

        //The display icon is changed to show the currently selected color.
        $('#currentColor').css('background-color', strokeColor);
    });

    //Changes the color based on the color picker.
    $('#colorPicker').on('change', function () {
        color = $(this).val();

        //All other selected colors are deselected.
        $(this).parent().children().not(this).removeClass('selectedButton');
        $(this).addClass('selectedButton');

        $('#currentColor').css('background-color', color);
    });

    $('.commandButton').on('click', function () {
        //The command is updated based on the button pressed.
        if ($(this).is('#freeCommand')) {
            command = FREE;
        }
        if ($(this).is('#lineCommand')) {
            command = FREE;
        }
        if ($(this).is('#rectCommand')) {
            command = FREE;
        }
        if ($(this).is('#fillRectCommand')) {
            command = FREE;
        }
        if ($(this).is('#ovalCommand')) {
            command = FREE;
        }
        if ($(this).is('#fillOvalCommand')) {
            command = FREE;
        }
        if ($(this).is('#eraseCommand')) {
            command = FREE;
        }

        //All selected commands are deselected
        $(this).parent().children().not(this).removeClass('selectedButton');
        $(this).addClass('selectedButton');
    });

    function drawToContainer(container_ID, Image_ID) {
        //TODO: Update the width andheight to something more elegant
        var stage = new Kinetic.Stage({
            container: 'container_ID',
            width: $('#' + container_ID).width(),
            height: $('#' + container_ID).height()
        });

        var layer = new Kenetic.Layer();

        //Used to prevent error from drawing on empty canvas.
        var baseRect = new Kenetic.Rect({
            x: 0,
            y: 0,
            width: stage.getWidth(),
            height: stage.getHeight()
        });

        layer.add(rect);
        stage.add(layer);
        stage.draw();

        //Gets all existing shapes belonging to given image.
        $.ajax({
            type: "POST",
            url: "/Home/Shape_GetByImage",
            data: { Image_ID: Image_ID },
            type: "json"
        });
    }
});