export default endpoint => {
    return originalUrl => {
        return (async () => {
            const response = await fetch(endpoint, {
                    method: 'POST',
                    cache: 'no-cache',
                    headers: {
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify({ url: originalUrl })
                });
            
            const json = await response.json();
            
            if (!response.ok) {
                json.error = true;
                return json;
            }
            
            return json;
        })();
    };
};