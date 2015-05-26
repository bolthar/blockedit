
var loadTemplates = function () {
    $.get('Scripts/Element/Templates.html', function (templates) {
        $('body').append('<div style="display:none">' + templates + '<\/div>');
    });
};

loadTemplates();

var ElementsViewModel = function () {

    var self = this;
    this.Note = null;

    this.Elements = ko.observableArray([]);

    this.callbacks = {
        onChanged : function(elementData) {
            $.post('/api/note/' + self.Note.Id + '/elements/' + elementData.Id, { '': JSON.stringify(elementData) });
        }
    };

    this.ElementsChanged = function (note, elementData) {

        self.Note = note;
        self.Elements.removeAll();
        var newElements = $.map(elementData, function (ed) { return new TextElementViewModel(ed, self.callbacks); });
        if (newElements.length > 0) {
            for (var i = 0; i < newElements.length; i++) {
                self.Elements.push(newElements[i]);
            }
        } else {
            $.post('/api/note/' + self.Note.Id + '/elements/', { '': JSON.stringify({ Text: '' }) }, function (newElementData) {
                self.Elements.push(new TextElementViewModel(newElementData, self.callbacks));
            });
        }

    };

    this.selectTemplate = function (element) {
        return element.TemplateName;
    };

    this.onRender = function(elements) {
        $.each(elements, function(e) { expand(e); });
    };
}

