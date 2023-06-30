const employeeContainer = document.querySelector("#employees-container");
const searchBar = document.querySelector("#search-employee-field");

let pageReportID;
let employees;
let employeeTemplate;

setEmployeeTemplate();

getEmployees()
  .then(result =>
  {
    employees = result;
    loadEmployees();
  })
  .catch(error => console.log(error));

searchBar
  .addEventListener("input", () =>
  {
    const value = searchBar.value;
    for(let index = 0; index < employees.length; index++)
    {
      const currentEmployee = employees[index];
      const employeeNode = employeeContainer.children[index];
      
      if(!currentEmployee.username.toLowerCase().includes(value.toLowerCase()))
      {
        employeeNode.hidden = true;
      }
      else
      {
        employeeNode.hidden = false;
      }
    }
  });
function loadEmployees()
{
  for(let employee of employees)
  {
    const currentEmployee = employeeTemplate.cloneNode(true);
    const username = currentEmployee.querySelector("#username-field")
    
    username.textContent = employee.username;
    
    currentEmployee.querySelector("#assign-button")
      .addEventListener("click", async () =>
      {
        const response = await fetch("/Management/Report/Assign",
          {
            method: "post",
            headers: { "Accept": "application/json", "Content-Type": "application/json" },
            body: JSON.stringify({ UserId: employee.id, ReportId: pageReportID })
          });
        
        if(response.ok)
        {
          window.location.reload();
        }
      })
    
    employeeContainer.appendChild(currentEmployee);
  }
}

function setEmployeeTemplate()
{
  const employeeElement = document.querySelector("#employee-template");
  employeeTemplate = employeeElement.cloneNode(true);

  employeeElement.parentElement.removeChild(employeeElement);
}

function setReportId(reportId)
{
  pageReportID = reportId;
}

async function getEmployees()
{
  const response = await fetch("/Employees",
    {
      method: "get"
    });

  if(response.ok)
  {
    return await response.json();
  }
  else
  {
    console.log(await response.json());
  }
}