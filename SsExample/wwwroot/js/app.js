var SsExample;
(function (SsExample) {
    function scrollToElementId(elementId) {
        var element = document.getElementById(elementId);
        if (element) {
            element.scrollIntoView({ behavior: "smooth" });
        }
    }
    SsExample.scrollToElementId = scrollToElementId;
})(SsExample || (SsExample = {}));
//# sourceMappingURL=app.js.map