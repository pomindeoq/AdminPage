// Write your JavaScript code.

$(document).ready(function () {
    var next = 1;
    $(".add-more").click(function (e) {
        e.preventDefault();
        next = next + 1;
        var addto = "#field";
        var addRemove = "#field" + (next);      
        var newIn = '<div class="input-group" id="newField' + next + '"><input autocomplete="off" class="form-control" id="field' + next + '" name="field' + next + '" type="text" >';
        var newInput = $(newIn);
        var removeBtn = '<span class="input-group-btn"><button id="remove' + (next) + '" class="btn btn-danger remove-me" >-</button></span></div>';
        var removeButton = $(removeBtn);
        $(addto).after(newInput);
        $(addRemove).after(removeButton);
        $("#field").attr('data-source', $(addto).attr('data-source'));
        $("#count").val(next);

        $('.remove-me').click(function (e) {
            e.preventDefault();
            var fieldNum = this.id.charAt(this.id.length -1);
            var fieldID = "#field" + fieldNum;
            var newFieldID = "#newField" + fieldNum;
            $(this).remove();
            $(fieldID).remove();
            $(newFieldID).remove();
        });
    });


    $('#printBtn').click(function (e) {
        e.preventDefault();
        
    });

});

