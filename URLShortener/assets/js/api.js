export default endpoint => {
    return originalUrl => {
        return (async () => {
            const response = await fetch(endpoint, {
                method: 'POST',
                cache: 'no-cache',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: { url: originalUrl }
            });

            return await response.json();
        })();
    };
};