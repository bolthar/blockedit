
var ShellViewModel = function() {

    var self = this;
    
    this.onElementsChanged = function (note, elementData) {
        self.Elements.ElementsChanged(note, elementData);
    };
    
    this.Note = new NoteControlViewModel(this.onElementsChanged);
    this.Elements = new ElementsViewModel();
    
};

var shellVm = new ShellViewModel();

ko.applyBindings(shellVm.Note, $("#noteControl")[0]);
ko.applyBindings(shellVm.Elements, $("#elementsControl")[0]);



