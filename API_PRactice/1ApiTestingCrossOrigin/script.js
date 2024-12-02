function getDataWithToken() {
  fetchData();
}

async function getToken() {
  // const tokenUrl = 'http://localhost:53842/api/TokenGenerator/';
  // const payload = `{"username":"aniket","password":"password","role":"aniket"}`;
  const tokenUrl = 'http://localhost:50074/api/TokenGenerator';
  const payload = `{"username":"aniket","password":"password","role":"admin"}`;

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


// const apiUrl = "http://localhost:53842/api/LeaveApi/1";
const apiUrl = "http://localhost:50074/api/Product";

// Your JWT token


async function fetchData() {
  const jwtToken =await getToken();
  // console.log(jwtToken);
  try {
    const response = await fetch(apiUrl, {
      method: "GET",
      headers: {
        Authorization: `Bearer ${jwtToken}`,
        "Content-Type": "application/json",
      },
    });

    if (!response.ok) {
      throw new Error(`HTTP error! Status: ${response.status}`);
    }

    // Parse the response JSON
    const data = await response.json();
    const allData = data;
    console.log("Fetched  DAta Successfully With Token ::", allData);
  } catch (error) {
    console.error("Error fetching data:", error);
  }
}








