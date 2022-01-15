module.exports = {
    darkMode: 'class',
    content: ["./**/*.{razor,cs}", '../Blatomic.WASM/**/*.{razor,cs,html}', '../Blatomic.Server/**/*.{razor,cs}'],
    theme: {
        extend: {
            animation: {
                'spin-slow': 'spin 10s linear infinite',
            }
        },
    },
    plugins: [],
}
