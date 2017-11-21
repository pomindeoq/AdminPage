
$(document).ready(function () {
    
    $(".add-more").click(function (e) {
        e.preventDefault();       
        var addto = "#items";             
        var newIn = '<div class="input-group"><input autocomplete="off" value="1" class="form-control" type="text" ><span class="input-group-btn"><button class="btn btn-danger remove-me" >-</button></span></div>';
        var newInput = $(newIn);
        $(addto).append(newInput);      
        
       //$(addto).attr('data-source', $(addto).attr('data-source'));     
        
        $('.remove-me').click(function (e) {
            e.preventDefault();            
            $(this).parent().parent().remove();          
        });
    });

    $('#printBtn').click(function (e) {
        e.preventDefault();
        var items = [];
        $("form#formID input[type=text]").each(function () {
            var input = $(this).val();
            items.push(input);
        });
        var data = { items: items }
        var jsonString = JSON.stringify(data);
        console.log(jsonString);
        $.ajax({
            url: "/Item/CreateItems",
            data: jsonString,
            dataType: "json",
            contentType: 'application/json',
            type: 'POST',
            success: function (data) {
                alert("Successfull");
            },
            error: function () {
                alert("error");
            }
        });
    });

    


});

