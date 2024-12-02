function getDataWithoutToken() {
    fetchLeaveData();
  }
  
  // const LeaveApiUrl = "http://localhost:53842/api/LeaveApi/1";
  const LeaveApiUrl = "http://localhost:50074/api/Product";
  let allData = {};
  
  async function fetchLeaveData() {
    try {
      const response = await fetch(LeaveApiUrl, {
        method: "GET",
      });
  
      const data = await response.json();
  
      allData = data;
  
      console.log("Fetched and stored data: Without using Token", allData);
    } catch (error) {
      console.error("Error fetching data:", error);
    }
  }
  
  function Calculation() {
    var a = 10;
    var b = 100;
    console.log(a == b);
  
    console.log(a != b);
  }
   