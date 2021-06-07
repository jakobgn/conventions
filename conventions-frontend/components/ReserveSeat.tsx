import { useState } from "react";
import { useAuth0 } from "@auth0/auth0-react";
import { Talk } from "../pages/api/models";

export default function ReserveSeat({
  conventionId,
  talk,
}: {
  conventionId: number;
  talk: Talk;
}) {
  const { isAuthenticated, getAccessTokenSilently } = useAuth0();
  const [reserved, setReserved] = useState<boolean>();
  const reserveSeatApi = async (conventionId: number, talk: Talk) => {
    try {
      const accessToken = await getAccessTokenSilently({
        audience: "conventions",
        scope: "read:current_user",
      });
      const serverUrl = "http://localhost:26621";

      await fetch(`${serverUrl}/conventions/${conventionId}/talks/reserve`, {
        method: "POST", // or 'PUT'
        headers: {
          "Content-Type": "application/json",
          Authorization: "Bearer " + accessToken,
        },
        body: JSON.stringify(talk),
      });

      setReserved(true);
    } catch (error) {
      //handle
    }
  };

  if (!isAuthenticated) {
    return <></>;
  }
  return reserved ? (
    <p>reserved</p>
  ) : (
    <button onClick={() => reserveSeatApi(conventionId, talk)}>
      Reserve seat
    </button>
  );
}
