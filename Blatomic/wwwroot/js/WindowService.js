function preventDefault(e) {
    e.preventDefault();
}

var supportsPassive = false;
try {
    window.addEventListener("test", null, Object.defineProperty({}, 'passive', {
        get: function () { supportsPassive = true; }
    }));
} catch (e) { }

var wheelOpt = supportsPassive ? { passive: false } : false;

export function DisableTouchScroll() {
    window.addEventListener('touchmove', preventDefault, wheelOpt);
}

export function EnableTouchScroll() {
    window.removeEventListener('touchmove', preventDefault, wheelOpt);
}