namespace SsExample {
    export function scrollToElementId(elementId): void {
        let element = document.getElementById( elementId );
        if ( element ) { element.scrollIntoView( {behavior: "smooth"}); }
    }
}