import { useState, useEffect } from "react";
import { IdToken, useAuth0 } from "@auth0/auth0-react";
import { Convention } from "../pages/api/mock";

const ROLE_CLAIM =
  "http://schemas.microsoft.com/ws/2008/06/identity/claims/role";

export default function RegisterEvent({onAddConvention} : {onAddConvention: Function}) {
  const {
    user,
    isAuthenticated,
    isLoading,
    getAccessTokenSilently,
  } = useAuth0();

  const registerTalkApi = async () => {
    try {
      const accessToken = await getAccessTokenSilently({
        audience: "conventions",
        scope: "read:current_user",
      });
      const serverUrl = "http://localhost:26621";
      const response = await (
        await fetch(`${serverUrl}/conventions`, {
          method: "POST", // or 'PUT'
          headers: {
            "Content-Type": "application/json",
            Authorization: "Bearer " + accessToken,
          },
          body: JSON.stringify({}),
        })
      ).json();
      onAddConvention(response)

    } catch (error) {
      //handle
    }
  };
  return (
    <>
      {user?.[ROLE_CLAIM]?.includes("Admin") && (
        <button onClick={registerTalkApi}>Create event</button>
      )}
    </>
  );
}
