export function GetBoundingClientRect(element) {
    return element.getBoundingClientRect();
}

export function GetChildrenBoundingClientRect(element) {
    return element.childNodes.map(child => {
        return child.getBoundingClientRect();
    })
}