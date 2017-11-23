
$(document).ready(function () {
    
    $(".add-more").click(function (e) {
        e.preventDefault();       
        var addto = "#items";             
        var newIn = '<div class="input-group"><input autocomplete="off" value="1" class="form-control" type="text" placeholder="Enter Point Value"><span class="input-group-btn"><button class="btn btn-danger remove-me" >-</button></span></div>';
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
        $.ajax({
            url: "/Item/CreateItems",
            data: jsonString,
            dataType: "json",
            contentType: 'application/json',
            type: 'POST',
            success: function (data) {
                alert("Items successfully added to user, press Enter to print labels");
                
                // select printer to print on
                var printers = dymo.label.framework.getPrinters();
                if (printers.length == 0)
                    throw "No DYMO printers are installed. Install DYMO printers.";

                var printerName = "";
                for (var i = 0; i < printers.length; ++i) {
                    var printer = printers[i];
                    if (printer.printerType == "LabelWriterPrinter") {
                        printerName = printer.name;
                        break;
                    }
                }
                if (printerName == "")
                    throw "No LabelWriter printers found. Install LabelWriter printer";
                // open label
                var labelXml = '<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n<DieCutLabel Version=\"8.0\" Units=\"twips\">\r\n\t<PaperOrientation>Landscape<\/PaperOrientation>\r\n\t<Id>Storage<\/Id>\r\n\t<IsOutlined>false<\/IsOutlined>\r\n\t<PaperName>30258 Diskette<\/PaperName>\r\n\t<DrawCommands>\r\n\t\t<RoundRectangle X=\"0\" Y=\"0\" Width=\"3060\" Height=\"3960\" Rx=\"270\" Ry=\"270\" \/>\r\n\t<\/DrawCommands>\r\n\t<ObjectInfo>\r\n\t\t<BarcodeObject>\r\n\t\t\t<Name>BARCODE<\/Name>\r\n\t\t\t<ForeColor Alpha=\"255\" Red=\"0\" Green=\"0\" Blue=\"0\" \/>\r\n\t\t\t<BackColor Alpha=\"0\" Red=\"255\" Green=\"255\" Blue=\"255\" \/>\r\n\t\t\t<LinkedObjectName \/>\r\n\t\t\t<Rotation>Rotation0<\/Rotation>\r\n\t\t\t<IsMirrored>False<\/IsMirrored>\r\n\t\t\t<IsVariable>True<\/IsVariable>\r\n\t\t\t<GroupID>-1<\/GroupID>\r\n\t\t\t<IsOutlined>False<\/IsOutlined>\r\n\t\t\t<Text>12345<\/Text>\r\n\t\t\t<Type>Code39<\/Type>\r\n\t\t\t<Size>Large<\/Size>\r\n\t\t\t<TextPosition>None<\/TextPosition>\r\n\t\t\t<TextFont Family=\"Arial\" Size=\"8\" Bold=\"False\" Italic=\"False\" Underline=\"False\" Strikeout=\"False\" \/>\r\n\t\t\t<CheckSumFont Family=\"Arial\" Size=\"8\" Bold=\"False\" Italic=\"False\" Underline=\"False\" Strikeout=\"False\" \/>\r\n\t\t\t<TextEmbedding>None<\/TextEmbedding>\r\n\t\t\t<ECLevel>0<\/ECLevel>\r\n\t\t\t<HorizontalAlignment>Center<\/HorizontalAlignment>\r\n\t\t\t<QuietZonesPadding Left=\"0\" Top=\"0\" Right=\"0\" Bottom=\"0\" \/>\r\n\t\t<\/BarcodeObject>\r\n\t\t<Bounds X=\"317\" Y=\"576\" Width=\"3455\" Height=\"1948\" \/>\r\n\t<\/ObjectInfo>\r\n<\/DieCutLabel>';
                var label = dymo.label.framework.openLabelXml(labelXml);

                for (var itemId in data) {
                    label.setObjectText("BARCODE", data[itemId]);
                    console.log(data[itemId]);
                    label.print(printerName);
                }
                alert("All labels printed.")
                location.reload();
                                                  
            },
            error: function () {
                alert("error");
            }
        });
    });

    


});

