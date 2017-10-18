Type.registerNamespace("Sitefinity.Samples.UserGeneratedContent.Fields.ImageUrlField");

Sitefinity.Samples.UserGeneratedContent.Fields.ImageUrlField.ImageUrlFieldControl = function (element) {
    Sitefinity.Samples.UserGeneratedContent.Fields.ImageUrlField.ImageUrlFieldControl.initializeBase(this, [element]);
    this._element = element;
    this._labelElement = null;
    this._textBoxElement = null;
}

Sitefinity.Samples.UserGeneratedContent.Fields.ImageUrlField.ImageUrlFieldControl.prototype = {
    initialize: function () {
        /* Here you can attach to events or do other initialization */      
        Sitefinity.Samples.UserGeneratedContent.Fields.ImageUrlField.ImageUrlFieldControl.callBaseMethod(this, "initialize");
    },

    dispose: function () {
        /*  this is the place to unbind/dispose the event handlers created in the initialize method */   
        Sitefinity.Samples.UserGeneratedContent.Fields.ImageUrlField.ImageUrlFieldControl.callBaseMethod(this, "dispose");
    },

    /* --------------------------------- public methods ---------------------------------- */

    /* --------------------------------- event handlers ---------------------------------- */

    /* --------------------------------- private methods --------------------------------- */

    _getTextValue: function(){
        if (this._textBoxElement) {
            return this._textBoxElement.value;
        }
        return null;
    },

    _clearTextBox: function () {
        if (this._textBoxElement != null) {
            this._textBoxElement.value = "";
        }
    },    

    /* --------------------------------- properties -------------------------------------- */
    get_value: function () {    
        var val = this._getTextValue();
        return val;
    },

    set_value: function (value) {
        this._clearTextBox();
        if (value !== undefined && value != null && this._textBoxElement != null) {
            this._textBoxElement.value = value;
            $(this._textBoxElement).next().attr('src', value);
        }
        this._value = value;
    },
    
    get_textBoxElement: function () {
        return this._textBoxElement;
    },

    set_textBoxElement: function (value) {
        this._textBoxElement = value;
    }    
};


Sitefinity.Samples.UserGeneratedContent.Fields.ImageUrlField.ImageUrlFieldControl.registerClass("Sitefinity.Samples.UserGeneratedContent.Fields.ImageUrlField.ImageUrlFieldControl", Telerik.Sitefinity.Web.UI.Fields.FieldControl);