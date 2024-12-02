const ApiCaller={

demo:"hello",
    getToken:  async function () {
        const tokenUrl = 'http://localhost:53842/api/TokenGenerator/';
        const payload = `{"username":"aniket","password":"password","role":"aniket"}`;

        try {
            const response = await fetch(tokenUrl, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: payload
            });

            if (!response.ok) {
                throw new Error('Failed to get token');
            }

            const data = await response.json();
            return data;
        } catch (error) {
            console.error('Error getting token:', error);
            return null;
        }
    }

    


}
