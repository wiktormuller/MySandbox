// React-router-dom imports
import { useLoaderData } from "react-router-dom";

// Helper functions
import { fetchData } from "../helpers";

// Loader function
export function dashboardLoader() {
    const userName = fetchData("userName");

    return { userName }
}

const Dashboard = () => {
    const { userName } = useLoaderData(); // Custom hook provided by RRD

    return (
        <div>
            <h1>{userName}</h1>
            Dashboard
        </div>
    );
}

export default Dashboard;