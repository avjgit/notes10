from twilio.rest import TwilioRestClient

account_sid = 'ACace289e5b485bcd82417d365b20f779b' 
auth_token = '4166c61bfb4a922047f9d0520db1194c'
client = TwilioRestClient(account_sid, auth_token)

message = client.sms.messages.create(
	body="well hello there",
	to="+371<mynumber>",
	from_="+371<mynumber>")

print message.sid