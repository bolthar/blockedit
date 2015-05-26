
var NoteViewModel = function(note, onElementsChanged) {

    var self = this;
    this.note = note;

    this.onNoteClicked = function () {
        self.selectNote();
    };

    this.selectNote = function() {
        $.get('/api/note/' + this.note.Id + '/elements', null, function (elementData) {
            onElementsChanged(self.note, elementData);
        });
    };
};

var NoteControlViewModel = function (onElementsChanged) {

    var self = this;
    this.notes = ko.observableArray([]);
    this.newNote = ko.observable("");

    this.addNote = function() {
        if (self.newNote() != "") {
            $.post('/api/note', { '': self.newNote() }, function (noteData) {
                var note = new NoteViewModel(noteData, onElementsChanged);
                self.notes.push(note);
                note.selectNote();
                self.newNote("");
            });
        }
    };
};