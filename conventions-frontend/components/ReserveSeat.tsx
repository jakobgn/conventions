import { useState, useEffect } from "react";
import { IdToken, useAuth0 } from "@auth0/auth0-react";

export default function ReserveSeat({
  conventionId,
  talkId,
}: {
  conventionId: number;
  talkId: number;
}) {
  const {
    user,
    isAuthenticated,
    isLoading,
    getIdTokenClaims,
    getAccessTokenSilently,
  } = useAuth0();
  const [reserved, setReserved] = useState<boolean>();
  const reserveSeatApi = async (conventionId: number, talkId: number) => {
    try {
      const accessToken = await getAccessTokenSilently({
        audience: "conventions",
        scope: "read:current_user",
      });
      const serverUrl = "http://localhost:26621";

      await fetch(
        `${serverUrl}/conventions/${conventionId}/talks/${talkId}/reserve`,
        {
          method: "POST", // or 'PUT'
          headers: {
            "Content-Type": "application/json",
            Authorization: "Bearer " + accessToken,
          },
          body: JSON.stringify({}),
        }
      );

      setReserved(true);
    } catch (error) {
      //handle
    }
  };

  if(!isAuthenticated){
    return <></>
  }
  return reserved ? (
    <p>reserved</p>
  ) : (
    <button onClick={() => reserveSeatApi(conventionId, talkId)}>
      Reserve seat
    </button>
  );
}
