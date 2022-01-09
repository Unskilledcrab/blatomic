export function CopyToClipboard(text) {
    navigator.clipboard.writeText(text).then(function () {
        return null;
    })
    .catch(function (error) {
        return error;
    });
}