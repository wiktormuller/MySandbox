// React-router-dom imports
import { Outlet, useLoaderData } from "react-router-dom";

// Assets
import wave from "../assets/wave.svg";

// Helper functions
import { fetchData } from "../helpers";

// Components
import Nav from "../components/Nav";

// Loader function
export function mainLoader() {
    const userName = fetchData("userName");

    return { userName }
}

const Main = () => { // Outlet - renders the child route's element
    const { userName } = useLoaderData(); // Custom hook provided by RRD

    return (
        <div className="layout">
            <Nav userName={userName} />
            <main>
                <Outlet />
            </main>
            <img src={wave} alt="" />
        </div>
    );
}

export default Main;