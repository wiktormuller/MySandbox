// RRD imports
import { redirect } from "react-router-dom";

// Helpers
import { deleteItem } from "../helpers";

// Library
import { toast } from "react-toastify";

export async function logoutAction() {
    // Delete the user
    deleteItem({
        key: "userName"
    });

    toast.success("You've deleted your account!");

    // Return redirect
    return redirect("/");
}