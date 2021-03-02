var JSInteropWithTypeScript;
(function (JSInteropWithTypeScript) {
    var ExampleJsFunctions = /** @class */ (function () {
        function ExampleJsFunctions() {
        }
        ExampleJsFunctions.prototype.showPrompt = function (message) {
            return prompt(message, 'Type anything here');
        };
        return ExampleJsFunctions;
    }());
    function Load() {
        window['exampleJsFunctions'] = new ExampleJsFunctions();
    }
    JSInteropWithTypeScript.Load = Load;
})(JSInteropWithTypeScript || (JSInteropWithTypeScript = {}));
JSInteropWithTypeScript.Load();
//# sourceMappingURL=example.js.map