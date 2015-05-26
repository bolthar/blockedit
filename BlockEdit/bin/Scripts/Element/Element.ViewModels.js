
var TextElementViewModel = function(elementData, callbacks) {

    var self = this;
    this.Id = elementData.Id;
    this.Text = ko.observable(elementData.Text);
    this.callbacks = callbacks;

    this.timer = null;

    this.toJson = function() {
        return {
            Id: self.Id,
            Type: 'TextElement',
            Text: self.Text()
        };
    };

    this.TemplateName = "TextElement_template";
    
    this.Text.subscribe(function () {
        clearTimeout(self.timer);
        self.timer = setTimeout(function () {
            self.callbacks.onChanged(self.toJson());
        }, 1000);
    });
}